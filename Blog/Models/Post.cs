using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Models
{
    public class Post
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime Created { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime Updated { get; set; }

        public string Title { get; set; }

        [Display(Name = "Text")]
        [UIHint("MultilineText")]
        public string Content { get; set; } 

        public Post()
        {
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }
    }
}