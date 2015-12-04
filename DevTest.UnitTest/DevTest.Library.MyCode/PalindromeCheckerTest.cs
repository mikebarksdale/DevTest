using System;
using System.Collections.Generic;
using DevTest.Library.MyCode;
using DevTest.Library.Palindrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevTest.UnitTest.DevTest.Library.MyCode
{
	[TestClass]
	public class PalindromeCheckerTest
	{
		#region Fields

		private IPalindromeChecker _palindromeCheckerImplementation;

		#endregion

		#region Public

		[TestMethod]
		public void IsPalindrome_SuppliedList()
		{
			//Arrange
			_palindromeCheckerImplementation = new MyPalindromeChecker();
			var wordListAndExpectedValue = new List<Tuple<string, bool>>
			{
				new Tuple<string, bool>(null, false),
				new Tuple<string, bool>(string.Empty, true),
				new Tuple<string, bool>("a", true),
				new Tuple<string, bool>("aa", true),
				new Tuple<string, bool>("ab", false),
				new Tuple<string, bool>("aba", true),
				new Tuple<string, bool>("\t\t", true),
				new Tuple<string, bool>("\t\n\t", true),
				new Tuple<string, bool>("a\ta\n\t", true),
				new Tuple<string, bool>("\tabcba\t", true),
				new Tuple<string, bool>("civic", true),
				new Tuple<string, bool>("kayak", true),
				new Tuple<string, bool>("radar", true),
				new Tuple<string, bool>("level", true),
				new Tuple<string, bool>("stats", true),
				new Tuple<string, bool>("rotator", true),
				new Tuple<string, bool>("aibohphobia", true),
				new Tuple<string, bool>("deified", true),
				new Tuple<string, bool>("rotor", true),
				new Tuple<string, bool>("turret", false),
				new Tuple<string, bool>("chicken", false),
				new Tuple<string, bool>("jabberwocky", false),
				new Tuple<string, bool>("turtle", false),
				new Tuple<string, bool>("elephant", false),
				new Tuple<string, bool>("cat", false),
				new Tuple<string, bool>("race car", true),
				new Tuple<string, bool>("fluent", false),
				new Tuple<string, bool>("castle", false)
			};

			foreach (var wordAndExpected in wordListAndExpectedValue)
			{
				// Act
				var result = _palindromeCheckerImplementation.IsPalindrome(wordAndExpected.Item1);

				// Assert
				Assert.AreEqual(result, wordAndExpected.Item2, "\"" + wordAndExpected.Item1 + "\" Is Bad");
			}
		}

		#endregion
	}
}