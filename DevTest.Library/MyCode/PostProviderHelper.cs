using System;
using System.Collections.Generic;
using System.Linq;
using DevTest.Library.Models;
using DevTest.Library.MyCode.Models;

namespace DevTest.Library.MyCode
{
	public class PostProviderHelper
	{
		#region Public

		/// <summary>
		///     Generates a list of comments, grouped by commenter.
		/// </summary>
		/// <param name="posts">The posts to join with the specified persons to create the return list</param>
		/// <param name="persons">The persons to join with the specifed posts to create the return list</param>
		/// <param name="personPredicate">A predicate to apply to the person list</param>
		/// <returns>
		///     A list of comments, grouped by the commenter who meet the predicates requirements
		/// </returns>
		public static IEnumerable<PostAndPerson> GroupCommentsByCommenter(IEnumerable<PostModel> posts,
			IEnumerable<PersonModel> persons,
			Func<PersonModel, bool> personPredicate)
		{
			if (posts == null)
				throw new ArgumentNullException("posts");
			
			if (persons == null)
				throw new ArgumentNullException("persons");

			var postsList = posts.ToList();
			var personList = persons.ToList();
			var returnList = new List<PostAndPerson>();

			// utilize the person predicate to filter person list.
			if (personPredicate != null)
				personList = personList.Where(personPredicate).ToList();

			// iterate over each post and comment to fill the return structure
			foreach (var post in postsList)
			{
				foreach (var comment in post.Comments)
				{
					var ancient = personList.FirstOrDefault(x => x.Id == comment.PersonId);
					if (ancient == null)
						continue;

					var postAndPerson = returnList.FirstOrDefault(x => x.Person.Id == ancient.Id);
					if (postAndPerson == null)
					{
						postAndPerson = new PostAndPerson {Person = ancient};
						returnList.Add(postAndPerson);
					}

					postAndPerson.Comments.Add(comment.Comment);
				}
			}

			return returnList;
		}

		/// <summary>
		///     Joins a list of posts and persons across the commenters and linked by fields
		/// </summary>
		/// <param name="posts">The posts to join with the specified persons to create the return list</param>
		/// <param name="persons">The persons to join with the specifed posts to create the return list</param>
		/// <returns>
		///     A list of all posts that contain the following information:
		///     <para>- User who made the post</para>
		///     <para>- The textual content of the post</para>
		///     <para>- The total number of comments</para>
		///     <para>- The user names of each commenter, separated by commas</para>
		/// </returns>
		public static IEnumerable<PostAndPerson> JointPostAndPersons(IEnumerable<PostModel> posts,
			IEnumerable<PersonModel> persons)
		{
			if (posts == null)
				throw new ArgumentNullException("posts");
			
			if (persons == null)
				throw new ArgumentNullException("persons");

			var postsList = posts.ToList();
			var personList = persons.ToList();

			return postsList.Join(
				personList,
				post => post.PersonPostedId,
				person => person.Id,
				(post, person) => new PostAndPerson
				{
					Person = person,
					PostContent = post.Content,
					Commenter = post.Comments.Join(
						personList,
						commentModel => commentModel.PersonId,
						personModel => personModel.Id,
						(model, personModel) => personModel)
						.ToList(),
					LikedBy = post.Comments.Join(
						personList,
						commentModel => commentModel.PersonId,
						personModel => personModel.Id,
						(model, personModel) => personModel)
						.ToList()
				})
				.ToList();
		}

		#endregion
	}
}