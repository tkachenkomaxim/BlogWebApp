using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public string Title { get; set; }

        public string Content { get; set; } 

        public PostViewModel()
        {
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }
    }
}