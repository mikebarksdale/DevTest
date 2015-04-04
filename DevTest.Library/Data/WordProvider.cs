using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevTest.Library.Extensions;

namespace DevTest.Library.Data
{
    /// <summary>
    /// Provides words. Do not modify this class.
    /// </summary>
    public static class WordProvider
    {
        /// <summary>
        /// Returns an array of words for exercise 1. Some may include palindromes.
        /// </summary>
        /// <returns>An array of words.</returns>
        public static string[] GetWords()
        {
            var wordList = new List<string>
            {
                "civic",
                "kayak",
                "radar",
                "level",
                "stats",
                "rotator",
                "aibohphobia",
                "deified",
                "rotor",
                "turret",
                "chicken",
                "jabberwocky",
                "turtle",
                "elephant",
                "cat",
                "race car",
                "fluent",
                "castle"
            };

            wordList.Randomize();

            return wordList.ToArray();
        }

        /// <summary>
        /// Returns a list between 10 and 30 numbered words for exercise 2.
        /// </summary>
        /// <returns>A list of words.</returns>
        public static IEnumerable<string> GetWordList()
        {
            var wordList = new List<string>();

            var maxWords = new Random().Next(10, 31);

            for (int x = 0; x < maxWords; x++)
                wordList.Add(string.Format("word{0}", x + 1));

            return wordList;
        }
    }
}
