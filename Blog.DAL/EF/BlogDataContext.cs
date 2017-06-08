using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace Blog.DAL
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}