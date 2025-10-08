using System;
using System.Collections.Generic;
using System.Linq;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Exceptions;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Model.POCOs;
using HVTApp.Model.Wrapper;

namespace HVTApp.Model
{
    public static class Extensions
    {
        /// <summary>
        /// Пользователь является текущим пользователем приложения
        /// </summary>
        /// <param name="user">Проверяемый пользователь</param>
        /// <returns></returns>
        public static bool IsAppCurrentUser(this User user)
        {
            return GlobalAppProperties.User.Id == user.Id;
        }

        /// <summary>
        /// Пользователь является текущим пользователем приложения
        /// </summary>
        /// <param name="userWrapper">Проверяемый пользователь</param>
        /// <returns></returns>
        public static bool IsAppCurrentUser(this UserWrapper userWrapper)
        {
            return userWrapper.Model.IsAppCurrentUser();
        }

        public static Region GetRegion(this Facility facility)
        {
            //по адресу объекта
            return facility.Address.Locality.Region;
        }

        /// <summary>
        /// Возвращает адрес компании или адрес родительской компании.
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public static Address GetCompanyOrParentAddress(this Company company)
        {
            //по населенному пункту владельца объекта (или его головных организаций)
            Address result = company.AddressLegal;
            while (company != null && result == null)
            {
                result = company.AddressLegal;
                company = company.ParentCompany;
            }

            return result;
        }

        public static string GetDeliveryAddressString(this SalesUnit salesUnit)
        {
            Address address = salesUnit.AddressDeliveryCalculated;
            return address == null ? "Адрес не определен." : address.ToString();
        }

        /// <summary>
        /// Возвращает ближайшую к дате сумму.
        /// </summary>
        /// <param name="sumsOnDates">Суммы</param>
        /// <param name="date">Дата</param>
        /// <returns></returns>
        public static ISumOnDate GetClosedSumOnDate(this IEnumerable<ISumOnDate> sumsOnDates, DateTime date)
        {
            if (sumsOnDates == null)
                throw new ArgumentNullException(nameof(sumsOnDates));

            return sumsOnDates
                .OrderBy(sumOnDate => Math.Abs((sumOnDate.Date - date).Ticks))
                .First();
        }

        /// <summary>
        /// Возвращает среднюю по кварталу
        /// </summary>
        /// <param name="sumsOnDates"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ISumOnDate GetAverageQuarterSum(this IEnumerable<ISumOnDate> sumsOnDates, DateTime date)
        {
            if (sumsOnDates == null)
                throw new ArgumentNullException(nameof(sumsOnDates));

            var quarterAbsolute = date.QuarterAbsolute();

            //суммы из квартала целевой даты (или ближайшего)
            var sums = sumsOnDates
                .GroupBy(sumOnDate => sumOnDate.Date.QuarterAbsolute())
                .OrderBy(x => Math.Abs(x.Key - quarterAbsolute))
                .First();

            var sumem = ExceptMistakes(sums.Select(x => x.Sum), 50).ToList();
            var sum = sumem.Any() 
                ? sumem.Average() 
                : sums.Select(x => x.Sum).Average();

            return new SumOnDate
            {
                Sum = sum,
                Date = sums.First().Date
            };
        }

        /// <summary>
        /// Исключить из последовательности те, что "выпадают"
        /// </summary>
        /// <param name="doubles"></param>
        /// <param name="percentage"></param>
        /// <returns></returns>
        private static IEnumerable<double> ExceptMistakes(IEnumerable<double> doubles, int percentage)
        {
            var result = doubles.ToList();

            int count;
            do
            {
                count = result.Count;
                var average = result.Average();
                foreach (var d in result.ToList())
                {
                    //удаление больших значений
                    if ((average) < (d * (1.0 - percentage / 100.0)))
                    {
                        result.Remove(d);
                    }
                    //удаление меньших значений
                    else if ((average) > (d * (1.0 + percentage / 100.0)))
                    {
                        result.Remove(d);
                    }
                }
            } while (result.Any() && count != result.Count);
            
            return result;
        }

        /// <summary>
        /// Квартал года
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int Quarter(this DateTime date)
        {
            var month = date.Month;
            if (month < 4) return 1;
            if (month < 7) return 2;
            if (month < 10) return 3;
            return 4;
        }

        /// <summary>
        /// Крартал с 0 года н.э.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int QuarterAbsolute(this DateTime date)
        {
            return (date.Year - 1) * 4 + date.Quarter();
        }

        /// <summary>
        /// Вернуть параметр номинального напряжения продукта (если его нет - null)
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static Parameter GetVoltageParameter(this Product product)
        {
            return product.ProductBlock.Parameters.FirstOrDefault(parameter => parameter.ParameterGroup.Id == GlobalAppProperties.Actual.VoltageGroup.Id);
        }

        /// <summary>
        /// Оставить параметр единственным в группе
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Parameter> LeaveParameterAloneInGroup(this IEnumerable<Parameter> parameters, Parameter parameterRequired)
        {
            foreach (var parameter in parameters)
            {
                if (parameter.Id == parameterRequired.Id)
                {
                    yield return parameter;
                }
                else
                {
                    if (parameter.ParameterGroup.Id != parameterRequired.ParameterGroup.Id)
                    {
                        yield return parameter;
                    }
                }
            }
        }

        public static IEnumerable<Parameter> GetParametersOfGroup(
            this IEnumerable<Parameter> parameters,
            Guid idOfParametersGroup)
        {
            return parameters.Where(x => x.ParameterGroup.Id == idOfParametersGroup);
        }

        /// <summary>
        /// Оставить параметры единственными в своих группах
        /// </summary>
        /// <param name="parameters">Все параметры</param>
        /// <param name="parametersRequired">Единственные параметры в своих группах</param>
        /// <returns></returns>
        public static IEnumerable<Parameter> LeaveParametersAloneInGroup(this IEnumerable<Parameter> parameters, IEnumerable<Parameter> parametersRequired)
        {
            var requiredParameters = parametersRequired as Parameter[] ?? parametersRequired.ToArray();
            foreach (var parameter in parameters)
            {
                if (requiredParameters.ContainsById(parameter))
                {
                    yield return parameter;
                }
                else
                {
                    var groups = requiredParameters
                        .Select(x => x.ParameterGroup)
                        .Distinct();
                    if (groups.ContainsById(parameter.ParameterGroup) == false)
                    {
                        yield return parameter;
                    }
                }
            }
        }

        public static IEnumerable<Parameter> RemoveUnreachable(this IEnumerable<Parameter> parameters)
        {
            var parametersAll = parameters as Parameter[] ?? parameters.ToArray();

            foreach (var parameter in parametersAll)
            {
                if (parameter.IsOrigin)
                    yield return parameter;

                if (parameter.Paths().Any(x => x.Parameters.AllContainsInById(parametersAll)))
                    yield return parameter;
            }
        }

        /// <summary>
        /// Вернуть головную сборку задач ТСП
        /// </summary>
        /// <param name="task"></param>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public static PriceEngineeringTasks GetPriceEngineeringTasks(this PriceEngineeringTask task, IUnitOfWork unitOfWork)
        {
            if (task.ParentPriceEngineeringTasksId.HasValue == false) 
                task = task.GetTopPriceEngineeringTask(unitOfWork);

            if (task.ParentPriceEngineeringTasksId.HasValue == false)
                throw new ArgumentException($"Задача ТСП не связана ни с одной сборкой задач. {nameof(GetPriceEngineeringTasks)} failed");

            return unitOfWork.Repository<PriceEngineeringTasks>().GetById(task.ParentPriceEngineeringTasksId.Value);
        }

        /// <summary>
        /// Вернуть верхнюю задачу ТСП
        /// </summary>
        /// <param name="task"></param>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public static PriceEngineeringTask GetTopPriceEngineeringTask(this PriceEngineeringTask task, IUnitOfWork unitOfWork)
        {
            task = unitOfWork.Repository<PriceEngineeringTask>().GetById(task.Id);
            if (task == null)
                throw new EntityNotInDataBaseException();

            while (task.ParentPriceEngineeringTaskId.HasValue)
            {
                task = unitOfWork.Repository<PriceEngineeringTask>().GetById(task.ParentPriceEngineeringTaskId.Value);
            }

            return task;
        }

        /// <summary>
        /// Сумма фиксированных затрат
        /// </summary>
        /// <param name="salesUnits1"></param>
        /// <returns></returns>
        public static double GetFixedCost(this IEnumerable<SalesUnit> salesUnits1)
        {
            {
                var salesUnits = salesUnits1 as SalesUnit[] ?? salesUnits1.ToArray();
                var productsIncluded = salesUnits
                    .SelectMany(salesUnit => salesUnit.ProductsIncluded)
                    .Distinct()
                    .ToList();

                //суммируем нестандартные ФЗ
                var result = productsIncluded
                    .Where(productIncluded => productIncluded.CustomFixedPrice.HasValue)
                    .Sum(productIncluded => productIncluded.CustomFixedPrice.Value * productIncluded.AmountOnUnit);

                //Суммируем стандартные ФЗ
                foreach (var pi in productsIncluded.Where(productIncluded => productIncluded.CustomFixedPrice.HasValue == false))
                {
                    var fc = pi.Product.ProductBlock.GetFixedCost(salesUnits.First().OrderInTakeDate);
                    if (fc.HasValue == false) continue;
                    result += fc.Value * pi.AmountOnUnit;
                }

                return result;
            }
        }

    }
}