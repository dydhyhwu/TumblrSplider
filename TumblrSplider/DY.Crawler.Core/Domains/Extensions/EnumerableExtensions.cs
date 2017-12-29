using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DY.Crawler.Core.Domains.Extensions
{
    public static class EnumerableExtensions
    {
        public static void each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (T item in items)
            {
                action(item);
            }
        }

        public static IEnumerable<int> to(this int start, int end)
        {
            for (int i = start; i <= end; i++) yield return i;
        }

        public static string get_content(this string url, HttpClient client)
        {
            try
            {
                return client.GetStringAsync(url).Result;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public static List<KeyValuePair<string, string>> get_params(this IEnumerable<AccountData> source)
        {
            return source.Select(x => new KeyValuePair<string, string>(x.Name, x.Value)).ToList();
        }

        public static IEnumerable<T> Distinct<T, V>(this IEnumerable<T> source, Func<T, V> key_selector)
        {
            return source.Distinct(new CommonEqualityComparer<T, V>(key_selector));
        }
    }

    public class CommonEqualityComparer<T, V> : IEqualityComparer<T>
    {
        private Func<T, V> key_selector;

        public CommonEqualityComparer(Func<T, V> key_selector)
        {
            this.key_selector = key_selector;
        }

        public bool Equals(T x, T y)
        {
            return EqualityComparer<V>.Default.Equals(key_selector(x), key_selector(y));
        }

        public int GetHashCode(T obj)
        {
            return EqualityComparer<V>.Default.GetHashCode(key_selector(obj));
        }
    }
}
