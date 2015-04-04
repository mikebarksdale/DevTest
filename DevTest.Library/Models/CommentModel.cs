﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTest.Library.Models
{
    public class CommentModel
    {
        public CommentModel()
        {
            CommentId = Guid.NewGuid().ToString();
        }

        public string CommentId { get; set; }
        public string Comment { get; set; }
        public string PersonId { get; set; }
    }
}
