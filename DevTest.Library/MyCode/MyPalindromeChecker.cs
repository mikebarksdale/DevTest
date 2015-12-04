using DevTest.Library.MyCode.Extension;
using DevTest.Library.Palindrome;

namespace DevTest.Library.MyCode
{
	public class MyPalindromeChecker : IPalindromeChecker
	{
		#region IPalindromeChecker Members

		/// <summary>
		///     Implement this method to accept a word and determine if it's a palindrome.
		/// </summary>
		/// <param name="word">A string of characters that may or may not be a palindrome.</param>
		/// <returns>A bool indicating whether or not the word is a palindrome.</returns>
		public bool IsPalindrome(string word)
		{
			return word.IsPalindrome();
		}

		#endregion
	}
}