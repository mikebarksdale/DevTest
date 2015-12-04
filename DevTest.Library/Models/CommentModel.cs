using System;

namespace DevTest.Library.Models
{
	public class CommentModel
	{
		#region  Properties

		public string Comment { get; set; }

		public string CommentId { get; set; }
		public string PersonId { get; set; }

		#endregion

		public CommentModel()
		{
			CommentId = Guid.NewGuid().ToString();
		}

		#region Public

		public override string ToString()
		{
			return Comment;
		}

		#endregion
	}
}