using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTest.Library.Models
{
    public class PersonModel
    {
        public PersonModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set;}
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
