using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace Blog.Models
{
    public class BlogDataContext1 : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}