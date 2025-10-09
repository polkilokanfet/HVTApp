using System;
using System.Collections.Generic;
using System.Linq;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Model.POCOs;

namespace HVTApp.Model
{
    public static class ParametersExtensions
    {
        #region IEnumerable<Parameter>

        /// <summary>
        /// Параметры без параметров "Деталей и Комплектов". Но если параметры входят в выделенный продукт - игнорируем их удаление.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="selectedProduct"></param>
        public static IEnumerable<Parameter> WithoutComplects(this IEnumerable<Parameter> parameters, Product selectedProduct = null)
        {
            foreach (var parameter in parameters)
            {
                //сохраняем параметры предварительно выбранного продукта
                if (selectedProduct != null)
                {
                    if (selectedProduct.ProductBlock.Parameters.ContainsById(parameter))
                    {
                        yield return parameter;
                        continue;
                    }
                }

                //парметры "обозначение комплекта"
                if (parameter.ParameterGroup.Id != GlobalAppProperties.Actual.ComplectDesignationGroup.Id &&
                    //параметры "Тип комплекта"
                    parameter.ParameterGroup.Id != GlobalAppProperties.Actual.ComplectsGroup.Id &&
                    //параметр "Комплекты и детали"
                    parameter.Id != GlobalAppProperties.Actual.ComplectsParameter.Id)
                {
                    yield return parameter;
                }
            }
        }

        /// <summary>
        /// Параметры без параметров "Новое оборудование"
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="selectedProduct"></param>
        public static IEnumerable<Parameter> WithoutNew(this IEnumerable<Parameter> parameters, Product selectedProduct = null)
        {
            foreach (var parameter in parameters)
            {
                //сохраняем параметры предварительно выбранного продукта
                if (selectedProduct != null)
                {
                    if (selectedProduct.ProductBlock.Parameters.ContainsById(parameter))
                    {
                        yield return parameter;
                        continue;
                    }
                }

                //парметры "обозначение"
                if (parameter.ParameterGroup.Id != GlobalAppProperties.Actual.NewProductParameterGroup.Id &&
                    //параметры "Тип комплекта"
                    parameter.ParameterGroup.Id != GlobalAppProperties.Actual.ComplectsGroup.Id &&
                    //параметр "Новое"
                    parameter.Id != GlobalAppProperties.Actual.NewProductParameter.Id)
                {
                    yield return parameter;
                }
            }
        }

        #endregion

        public static Parameter AddRequiredPreviousParameters(this Parameter parameter, params Parameter[] requiredPreviousParameters)
        {
            parameter.ParameterRelations.Add(new ParameterRelation
            {
                RequiredParameters = new List<Parameter>(requiredPreviousParameters)
            });
            return parameter;
        }

        public static double GetWeight(this Parameter parameter, ProductBlock block)
        {
            if (parameter.IsOrigin) return 2;
            return 1.0 / parameter.StepsToOrigin(block);
        }

        public static int StepsToOrigin(this Parameter parameter, ProductBlock block)
        {
            if (parameter.IsOrigin) return 0;

            var relations = parameter.ParameterRelations.Where(x => EnumerableExtensions.AllContainsIn(x.RequiredParameters, block.Parameters)).ToList();
            if (!relations.Any()) throw new ArgumentException("Передан параметр, который не должен быть в блоке.");

            var relation = relations.OrderBy(x => x.RequiredParameters.Count).Last();

            int result = 1;

            foreach (var requiredParameter in relation.RequiredParameters)
            {
                result += requiredParameter.StepsToOrigin(block);
            }

            return result;
        }

        public static bool IsComplectsGroup(this ParameterGroup parameterGroup)
        {
            return GlobalAppProperties.Actual.ComplectsGroup.Id == parameterGroup.Id;
        }

        public static bool IsComplectDesignationGroup(this ParameterGroup parameterGroup)
        {
            return GlobalAppProperties.Actual.ComplectDesignationGroup.Id == parameterGroup.Id;
        }
    }
}