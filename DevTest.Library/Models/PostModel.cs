using System;
using System.Collections.Generic;

namespace DevTest.Library.Models
{
	public class PostModel
	{
		#region  Properties

		public IList<CommentModel> Comments { get; set; }
		public string Content { get; set; }
		public string PersonPostedId { get; set; }
		public IList<string> PersonsLiked { get; set; }

		public string PostId { get; set; }

		#endregion

		public PostModel()
		{
			PostId = Guid.NewGuid().ToString();
		}
	}
}