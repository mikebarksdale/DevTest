using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DevTest.Library.Data;
using DevTest.Library.Models;
using DevTest.Library.MyCode;

namespace DevTest.Web.Controllers
{
	public class HomeController : Controller
	{
		#region Public

		[HttpPost]
		public ActionResult GetExcersizeResults()
		{
			var results = new List<string>();

			var posts = PostProvider.GetPosts().ToList();
			var persons = PostProvider.GetPersons().ToList();

			Func<PersonModel, bool> personsOlderThan25Predicate = person => person.BirthDate < DateTime.Now.AddYears(-25);
			PostProviderHelper.GroupCommentsByCommenter(posts, persons, personsOlderThan25Predicate)
				.ToList()
				.ForEach(x =>
				{
					results.Add(x.Person.ToString());
					results.Add("-----");
					x.Comments.ForEach(comment => results.Add(comment));
					results.Add(string.Empty);
				});

			results.Add("End of exercise 3.3.");
			results.Add(string.Empty);

			return Json(results);
		}

		public ActionResult Index()
		{
			return View();
		}

		#endregion
	}
}