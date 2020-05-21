using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Extension
{
    /// <summary>
    /// Extension for IList
    /// </summary>
    public static class IListExtensions
    {
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
        /// <summary>
        /// method 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static IList<T> Limit<T>(this IList<T> list, int limit)
        {
            if (list.Count <= limit || limit == 0)
            {
                return list;
            }
            List<T> newList = new List<T>();
            foreach (T item in list)
            {
                newList.Add(item);
                if (newList.Count >= limit)
                {
                    break;
                }
            }
            return newList;
        }
        /// <summary>
        /// method for compare two lists -int
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static bool Compare(this IList<int> list1, IList<int> list2)
        {
            List<int> firstNotSecond = list1.Except(list2).ToList();
            List<int> secondNotFirst = list2.Except(list1).ToList();
            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }
        public static bool Compare(this IList<Guid> list1, IList<Guid> list2)
        {
            List<Guid> firstNotSecond = list1.Except(list2).ToList();
            List<Guid> secondNotFirst = list2.Except(list1).ToList();
            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }
    }
}
