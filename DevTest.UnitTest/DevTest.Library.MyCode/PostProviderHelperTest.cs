using System;
using System.Collections.Generic;
using System.Linq;
using DevTest.Library.Data;
using DevTest.Library.Models;
using DevTest.Library.MyCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevTest.UnitTest.DevTest.Library.MyCode
{
	[TestClass]
	public class PostProviderHelperTest
	{
		#region Fields

		private List<PersonModel> _persons = new List<PersonModel>();
		private List<PostModel> _posts = new List<PostModel>();

		#endregion

		#region Public

		[TestInitialize]
		public void TestSetup()
		{
			_posts = PostProvider.GetPosts().ToList();
			_persons = PostProvider.GetPersons().ToList();
		}
		
		[TestMethod]
		public void JointPostAndPersons_CorruptedPersonId()
		{
			//Arrange
			_persons.First().Id = string.Empty;
			_posts.First().Comments[0].PersonId = "qqqq";

			// Act
			var output = PostProviderHelper.JointPostAndPersons(_posts, _persons);

			// Assert
			Assert.IsTrue(output.Any());
		}

		[TestMethod]
		public void JointPostAndPersons_EmptyCommentsList()
		{
			//Arrange
			_posts.ForEach(post => post.Comments = new List<CommentModel>());

			// Act
			var output = PostProviderHelper.JointPostAndPersons(_posts, _persons);

			// Assert
			Assert.IsTrue(output.Any());
		}

		[TestMethod]
		public void JointPostAndPersons_EmptyPersonList()
		{
			//Arrange
			_persons = new List<PersonModel>();

			// Act
			var output = PostProviderHelper.JointPostAndPersons(_posts, _persons);

			// Assert
			Assert.IsFalse(output.Any());
		}

		[TestMethod, ExpectedException(typeof (ArgumentNullException))]
		public void JointPostAndPersons_NullPersons()
		{
			//Arrange


			//Act
			var output = PostProviderHelper.JointPostAndPersons(_posts, null);
		}

		[TestMethod, ExpectedException(typeof (ArgumentNullException))]
		public void JointPostAndPersons_NullPost()
		{
			//Arrange

			//Act
			var output = PostProviderHelper.JointPostAndPersons(null, _persons);
		}

		[TestMethod]
		public void JointPostAndPersons_Works()
		{
			//Arrange

			// Act
			var output = PostProviderHelper.JointPostAndPersons(_posts, _persons);

			// Assert
			Assert.IsTrue(output.Any());
		}
		
		[TestMethod]
		public void GroupCommentsByCommenter_Works()
		{
			//Arrange
			Func<PersonModel, bool> personsOlderThan25Predicate = person => person.BirthDate < DateTime.Now.AddYears(-25);

			// Act
			var output = PostProviderHelper.GroupCommentsByCommenter(_posts, _persons, personsOlderThan25Predicate);

			// Assert
			Assert.IsTrue(output.Any());
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void GroupCommentsByCommenter_NullPersons()
		{
			//Arrange
			Func<PersonModel, bool> personsOlderThan25Predicate = person => person.BirthDate < DateTime.Now.AddYears(-25);
			_persons = null;

			// Act
			PostProviderHelper.GroupCommentsByCommenter(_posts, _persons, personsOlderThan25Predicate);

			// Assert
			Assert.Fail("ArgumentNullException should have been thrown");
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void GroupCommentsByCommenter_NullPosts()
		{
			//Arrange
			Func<PersonModel, bool> personsOlderThan25Predicate = person => person.BirthDate < DateTime.Now.AddYears(-25);
			_posts = null;

			// Act
			PostProviderHelper.GroupCommentsByCommenter(_posts, _persons, personsOlderThan25Predicate);

			// Assert
			Assert.Fail("ArgumentNullException should have been thrown");
		}

		[TestMethod]
		public void GroupCommentsByCommenter_NullPredicate()
		{
			//Arrange
			Func<PersonModel, bool> personsOlderThan25Predicate = person => person.BirthDate < DateTime.Now.AddYears(-25);

			// Act
			var output = PostProviderHelper.GroupCommentsByCommenter(_posts, _persons, personsOlderThan25Predicate);

			// Assert
			Assert.IsTrue(output.Any());
		}

		[TestMethod]
		public void GroupCommentsByCommenter_EmptyPersonsList()
		{
			//Arrange
			_persons = new List<PersonModel>();
			Func<PersonModel, bool> personsOlderThan25Predicate = null;

			// Act
			var output = PostProviderHelper.GroupCommentsByCommenter(_posts, _persons, personsOlderThan25Predicate);

			// Assert
			Assert.IsFalse(output.Any());
		}

		[TestMethod]
		public void GroupCommentsByCommenter_EmptyPostList()
		{
			//Arrange
			_posts = new List<PostModel>();
			Func<PersonModel, bool> personsOlderThan25Predicate = null;

			// Act
			var output = PostProviderHelper.GroupCommentsByCommenter(_posts, _persons, personsOlderThan25Predicate);

			// Assert
			Assert.IsFalse(output.Any());
		}

		[TestMethod]
		public void GroupCommentsByCommenter_PersonPredicateApplied()
		{
			//Arrange
			Func<PersonModel, bool> personsOlderThan25Predicate = person => person.BirthDate < DateTime.Now.AddYears(-25); ;

			// Act
			var nonFiltered = PostProviderHelper.GroupCommentsByCommenter(_posts, _persons, null);
			var filtered = PostProviderHelper.GroupCommentsByCommenter(_posts, _persons, personsOlderThan25Predicate);
			// Assert
			Assert.IsTrue(nonFiltered.Count() > filtered.Count());
		}

		#endregion
	}
}