using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blog.DAL;

namespace Blog.BLL
{
    public static class BlogManager
    {
        private static BlogDataContext _blogContext;

        static BlogManager()
        {
            BlogDataContext _blogContext = new BlogDataContext();
        }

        static List<Post> GetAllPosts()
        {
            return _blogContext.Posts.ToList();
        }   
        static PostViewModel GetPost()
        {
           
        }
    }
}
