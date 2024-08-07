using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStracHW.lib.Linq
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Skip<T>(this IEnumerable<T> source, int count)
        {
            int skipped = 0;
            foreach (var item in source)
            {
                if (skipped >= count)
                {
                    yield return item;
                }
                else
                {
                    skipped++;
                }
            }
        }

        public static IEnumerable<T> Take<T>(this IEnumerable<T> source, int count)
        {
            int taken = 0;
            foreach (var item in source)
            {
                if (taken < count)
                {
                    yield return item;
                    taken++;
                }
                else
                {
                    yield break;
                }
            }
        }

        public static T First<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            throw new InvalidOperationException("No matching element found");
        }

        public static IEnumerable<T> SkipWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            bool yieldStarted = false;
            foreach (var item in source)
            {
                if (!yieldStarted && !predicate(item))
                {
                    yieldStarted = true;
                }
                if (yieldStarted)
                {
                    yield return item;
                }
                }
            }
        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
                else
                {
                    yield break;
                }
            }
        }

        public static T Last<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            T last = default;
            bool found = false;
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    last = item;
                    found = true;
                }
            }
            if (!found) throw new InvalidOperationException("No matching element found");
            return last;
        }

        public static IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }
        public static IEnumerable<TResult> SelectMany<T, TResult>(this IEnumerable<T> source, Func<T, IEnumerable<TResult>> selector)
        {
            foreach (var item in source)
            {
                foreach (var subItem in selector(item))
                {
                    yield return subItem;
                }
            }
        }

        public static bool All<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (!predicate(item))
                {
                     return false;
                }
            }
           return true;
        }

        public static bool Any<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
