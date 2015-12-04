using System.Collections.Generic;
using DevTest.Library.Models;

namespace DevTest.Library.MyCode.Models
{
	public class PostAndPerson
	{
		#region Fields

		private List<PersonModel> _commenter = new List<PersonModel>();
		private List<string> _comments = new List<string>();
		private List<PersonModel> _likedBy = new List<PersonModel>();

		#endregion

		#region  Properties

		public List<PersonModel> Commenter
		{
			get { return _commenter; }
			set { _commenter = value; }
		}

		public List<string> Comments
		{
			get { return _comments; }
			set { _comments = value; }
		}

		public List<PersonModel> LikedBy
		{
			get { return _likedBy; }
			set { _likedBy = value; }
		}

		public PersonModel Person { get; set; }
		public string PostContent { get; set; }

		#endregion
	}
}