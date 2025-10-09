using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HVTApp.Infrastructure.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var element in enumerable)
            {
                action.Invoke(element);
            }
        }

        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        /// <summary>
        /// Члены коллекций совпадают.
        /// </summary>
        /// <typeparam name="T">Тип данных в перечислениях</typeparam>
        /// <param name="first">Первое перечисление</param>
        /// <param name="second">Второе перечисление</param>
        /// <param name="comparer">Спопсоб сравнения</param>
        /// <returns></returns>
        public static bool MembersAreSame<T>(this IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T> comparer = null)
        {
            var firstArray = first as T[] ?? first.ToArray();
            var secondArray = second as T[] ?? second.ToArray();

            if (firstArray.Length != secondArray.Length) return false;

            if (comparer == null)
                return !firstArray.Except(secondArray).Any() && !secondArray.Except(firstArray).Any();

            return !firstArray.Except(secondArray, comparer).Any() && !secondArray.Except(firstArray, comparer).Any();
        }

        /// <summary>
        /// Последовательность полностью содержит другую последовательность.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"> Последовательновсть, которая содержится в другой </param>
        /// <param name="second"> Последовательность в которой содержится другая </param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static bool AllContainsIn<T>(this IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T> comparer = null)
        {
            if (second == null) throw new ArgumentNullException(nameof(second));

            var firstArray = first as T[] ?? first.ToArray();
            var secondArray = second as T[] ?? second.ToArray();

            if (!secondArray.Any()) throw new ArgumentException("Передано перечисление не содержащее членов.", nameof(second));
            if (!firstArray.Any()) throw new ArgumentException("Передано перечисление не содержащее членов.", nameof(first));

            return comparer == null 
                ? firstArray.All(x => secondArray.Contains(x)) 
                : firstArray.All(x => secondArray.Contains(x, comparer));
        }

        /// <summary>
        /// Последовательность полностью содержит другую последовательность (по Id).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"> Последовательность, которая содержится в другой </param>
        /// <param name="second"> Последовательность в которой содержится другая </param>
        /// <returns></returns>
        public static bool AllContainsInById<T>(this IEnumerable<T> first, IEnumerable<T> second)
            where T : IId
        {
            if (second == null) throw new ArgumentNullException(nameof(second));

            var firstList = first.Select(x => x.Id).ToList();
            var secondList = second.Select(x => x.Id).ToList();

            if (!secondList.Any()) throw new ArgumentException("Передано перечисление не содержащее членов.", nameof(second));
            if (!firstList.Any()) throw new ArgumentException("Передано перечисление не содержащее членов.", nameof(first));

            return firstList.All(x => secondList.Contains(x));
        }


        /// <summary>
        /// Последовательность содержит элемент с таким Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="objId"></param>
        /// <returns></returns>
        public static bool ContainsById<T>(this IEnumerable<T> enumerable, IId objId)
            where T : IId
        {
            if(objId == null)
                throw new ArgumentNullException(nameof(objId));

            return enumerable.Select(x => x.Id).Contains(objId.Id);
        }

        public static T GetById<T>(this IEnumerable<T> enumerable, IId objId)
            where T : IId
        {
            return enumerable.SingleOrDefault(x => x.Id == objId.Id);
        }

        public static bool RemoveById<T>(this ICollection<T> collection, IId objId)
            where T : IId
        {
            var item = collection.Single(x => x.Id == objId.Id);
            return collection.Remove(item);
        }


        public static void RemoveIfContainsById<T>(this ICollection<T> collection, IId objId)
            where T : IId
        {
            if (collection.ContainsById(objId))
                collection.RemoveById(objId);
        }

        /// <summary>
        /// Удаление из словаря записи с соответствующим ключом (если такая запись есть)
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool RemoveIfContainsById<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            if (dictionary.ContainsKey(key) == false) return false;

            dictionary.Remove(key);
            return true;

        }

        /// <summary>
        /// Сначала удаляет элемент из коллекции по Id (если он есть),
        /// потом добавляет элемент.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="objId"></param>
        public static void ReAddById<T>(this ICollection<T> collection, T objId)
            where T : IId
        {
            collection.RemoveIfContainsById(objId);
            collection.Add(objId);
        }

        /// <summary>
        /// Заменить сущности на сущности из соответствующего UnitOfWork
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public static IEnumerable<T> ChangeUnitOfWork<T>(this IEnumerable<T> enumerable, IUnitOfWork unitOfWork) where T : class, IBaseEntity
        {
            return enumerable.Select(x => unitOfWork.Repository<T>().GetById(x.Id));
        }

        /// <summary>
        /// Заменить сущность на сущность из соответствующего UnitOfWork
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public static T ChangeUnitOfWork<T>(this T entity, IUnitOfWork unitOfWork) where T : class,IBaseEntity
        {
            return unitOfWork.Repository<T>().GetById(entity.Id);
        }

        public static string ToDistinctOrderedString<T>(this IEnumerable<T> enumerable, string separator = "; ")
        {
            var enumerable1 = enumerable as T[] ?? enumerable.ToArray();
            return enumerable1.Any() == false || enumerable1.All(x => x == null)
                ? string.Empty
                : string.Join(separator, enumerable1.Where(x => x != null).Select(x => x.ToString()).Distinct().OrderBy(x => x));
        }

        public static string ToStringEnum<T>(this IEnumerable<T> enumerable, string separator = "; ")
        {
            var enumerable1 = enumerable as T[] ?? enumerable.ToArray();
            return enumerable1.Any() == false || enumerable1.All(x => x == null)
                ? string.Empty 
                : string.Join(separator, enumerable1.Where(x => x != null).Select(x => x.ToString()).Distinct());
        }

        public static IReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> enumerable)
        {
            return new ReadOnlyCollection<T>(enumerable.ToList());
        }

        public static IEnumerable<T> Intersect<T>(this IEnumerable<IEnumerable<T>> enumerables)
        {
            //if (enumerables.Count() == 1)
            //    return enumerables.First();

            var enumerables1 = enumerables as IEnumerable<T>[] ?? enumerables.ToArray();
            var result = enumerables1.First();
            foreach (var enumerable in enumerables1.Skip(1))
            {
                result = result.Intersect(enumerable);
            }
            return result;
        }

        public static IEnumerable<T> Union<T>(this IEnumerable<IEnumerable<T>> enumerables)
        {
            var enumerables1 = enumerables as IEnumerable<T>[] ?? enumerables.ToArray();
            var result = enumerables1.First();
            foreach (var enumerable in enumerables1.Skip(1))
            {
                result = result.Union(enumerable);
            }
            return result;
        }
    }
}
