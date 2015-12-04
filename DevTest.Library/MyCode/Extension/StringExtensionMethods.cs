using System.Linq;

namespace DevTest.Library.MyCode.Extension
{
	public static class StringExtensionMethods
	{
		#region Public

		/// <summary>
		///     Determines if the specified string is a palindrome. White space is ignored.
		/// </summary>
		/// <param name="word">The string to check if its a palindrome </param>
		/// <returns>Whether the string is a palindrome</returns>
		public static bool IsPalindrome(this string word)
		{
			// a null string is not a word so false
			if (word == null)
				return false;

			// a zero length word is a palindrome
			if (word.Length <= 1)
				return true;

			// remove white spaces
			var workingWord = new string(word.Where(x => !char.IsWhiteSpace(x)).ToArray());

			// a zero length word is still a palindrome
			if (workingWord.Length <= 1)
				return true;

			var reverseIndex = workingWord.Length;
			for (var forwardIndex = 0; forwardIndex < reverseIndex; forwardIndex++)
			{
				if (workingWord[forwardIndex] != workingWord[--reverseIndex])
					return false;
			}

			return true;
		}

		#endregion
	}
}