using System.Collections.Generic;

namespace DevTest.Library.MyCode
{
	public static class PageingHelper
	{
		#region Public

		/// <summary>
		/// Takes in a word list and a page size and breakes apart the word list into pages 
		/// </summary>
		/// <param name="words">The word list to paginate</param>
		/// <param name="pageSize">The nuber of words per page. </param>
		/// <returns>A dictionary of pages and word lists.</returns>
		public static Dictionary<string, List<string>> Paginate(IEnumerable<string> words, int pageSize)
		{
			var paginated = new Dictionary<string, List<string>>();

			var counter = 0;
			var currentPage = new List<string>();

			foreach (var word in words)
			{
				if (counter%pageSize == 0)
				{
					var currentKey = string.Format("Page #{0}", (counter + 1)/pageSize + 1);
					currentPage = new List<string>();
					paginated.Add(currentKey, currentPage);
				}

				currentPage.Add(word);

				counter++;
			}

			return paginated;
		}

		#endregion
	}
}