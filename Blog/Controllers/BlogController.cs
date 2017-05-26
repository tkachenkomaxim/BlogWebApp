using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Blog.Models;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
       private BlogDataContext1 _blogContext1 = new BlogDataContext1();

        public ActionResult Index()
        {
            return View(_blogContext1.Posts.ToList());
        }

        [ChildActionOnly]
        public ActionResult PostInfo(Post post)
        {
            return PartialView("_PostInfo", post);
        }

        public ActionResult Post(int Id)
        {
            List<Post> post = _blogContext1.Posts.Where(x => x.Id == Id).ToList();
            return View(post[0]);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Post post)
        {
            _blogContext1.Posts.Add(post);
            _blogContext1.SaveChanges();
            return RedirectToAction("Post", new { post.Id });
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            List<Post> post = _blogContext1.Posts.Where(x => x.Id == Id).ToList();
            return View(post[0]);
        }
        [HttpPost]
        public ActionResult Edit(Post post)
        {
            var oldPost = _blogContext1.Posts.Where(x => x.Id == post.Id).FirstOrDefault();
            oldPost.Title = post.Title;
            oldPost.Content = post.Content;
            oldPost.Updated = DateTime.Now;
            _blogContext1.SaveChanges();

            return RedirectToAction("Post", new { post.Id });
        }


    }
}