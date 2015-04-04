using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTest.Library.Models
{
    public class PostModel
    {
        public PostModel()
        {
            PostId = Guid.NewGuid().ToString();
        }

        public string PostId { get; set; }
        public string Content { get; set; }
        public string PersonPostedId { get; set; }
        public IList<string> PersonsLiked { get; set; }
        public IList<CommentModel> Comments { get; set; }
    }
}
