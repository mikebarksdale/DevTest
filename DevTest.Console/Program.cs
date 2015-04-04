using DevTest.Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTest.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /* FOR ALL EXERCISES:
             * 
             * 1) All output needs to be sent to the console.
             * 2) Each exercise must be separated by a System.Console.ReadLine(); statement.
             * 3) All provided code must be used as is, unless otherwise explicitly stated.
             * 4) You may use the "MyCode" folder in DevTest.Library or within this class for any code you develop
             *    (unless otherwise specified).
             */ 

            /* Exercise 1:
             * 
             * Implement the IsPalindrome method in the MyPalindromeChecker class.
             * Use the WordProvider to retrieve a randomized list of words, which may or may not be palindromes.
             * Check each word returned by the WordProvider and output the word and whether or not is a palindrome. A
             * word may contain one or more whitespaces.
             * 
             * Example output:
             * Word: radar; IsPalindrome: true
             * Word: chicken; IsPalindrome: false
             */
            var words = WordProvider.GetWords();

            //implement exercise 1

            System.Console.WriteLine("End of exercise 1.");
            System.Console.ReadLine();

            /* Exercise 2:
             * 
             * Implement a paging algorithm using the given WordProvider. The provider will output a random number
             * of strings, in order. The list will include a minimum of 10 strings. A single page will be between 3 and 6
             * (inclusive) items. (represented by the pageSize variable). Your output should page all the way to the end 
             * of the list, showing every item in the list, and include the page number. Each page should be separated 
             * by a System.Console.ReadLine(); statement.
             * 
             * Example output (pageSize = 5):
             * 
             * Page #1
             * 1. word1
             * 2. word2
             * 3. word3
             * 4. word4
             * 5. word5
             * 
             * Page #2
             * 6. word6
             * 7. word7
             * 8. word8
             * 9. word9
             * 10. word10
             */
            var wordList = WordProvider.GetWordList();
            var pageSize = new Random().Next(3, 6);

            //implement exercise 2

            System.Console.WriteLine("End of exercise 2.");
            System.Console.ReadLine();

            /* Exercise 3:
             * 
             * Given the posts supplied by the PostProvider, do the following:
             * 
             * 1) Display a list of all posts that contain the following information:
             *      - User who made the post
             *      - The textual content of the post
             *      - The total number of comments
             *      - The user names of each commenter, separated by commas
             * 2) Display a list of users that have liked a post. Include the post content and a comma
             *    separated list of the user's names. 
             *    
             *    Example output:
             *    post1: sasha, brittany, eric
             *    post4: amber
             *    post8: monica
             *    
             * 3) Display a list of comments, grouped by commenter, made by persons older than 25 (as 
             *    of "today"). Include the commenter's name.
             *    
             *    Example output:
             *    steve
             *    -----
             *    Every strike brings me closer to the next home run. –Babe Ruth
             *    Everything you’ve ever wanted is on the other side of fear. –George Addair
             *    
             *    jeremy
             *    ------
             *    Challenges are what make life interesting and overcoming them is what makes life meaningful. –Joshua J. Marine
             *    There are no traffic jams along the extra mile. –Roger Staubach
             *    It’s your place in the world; it’s your life. Go on and do all you can with it, and make it the life you want to live. –Mae Jemison
             */
            var posts = PostProvider.GetPosts();

            //implement exercise 3.1

            System.Console.WriteLine("End of exercise 3.1.");
            System.Console.ReadLine();

            //implement exercise 3.2

            System.Console.WriteLine("End of exercise 3.2.");
            System.Console.ReadLine();

            //implement exercise 3.3

            System.Console.WriteLine("End of exercise 3.3.");
            System.Console.ReadLine();
        }
    }
}
