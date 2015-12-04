using System;

namespace DevTest.Library.Models
{
	public class PersonModel
	{
		#region  Properties

		public DateTime BirthDate { get; set; }

		public string Id { get; set; }
		public string UserName { get; set; }

		#endregion

		public PersonModel()
		{
			Id = Guid.NewGuid().ToString();
		}

		#region Public

		public override string ToString()
		{
			return UserName;
		}

		#endregion
	}
}