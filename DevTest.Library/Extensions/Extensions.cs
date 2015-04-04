using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTest.Library.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// http://stackoverflow.com/a/1262619
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Randomize<T>(this IList<T> list)
        {
            var random = new Random();
            var n = list.Count;
            while(n > 1)
            {
                n--;
                var k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
