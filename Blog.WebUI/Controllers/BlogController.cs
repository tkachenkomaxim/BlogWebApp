using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Blog.DAL;


namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index()
        {
            return View(BlogManager.GetAllPosts());
        }

        [ChildActionOnly]
        public ActionResult PostInfo(PostViewModel post)
        {
            return PartialView("_PostInfo", post);
        }

        public ActionResult Post(int Id)
        {
            PostViewModel post = _blogContext1.Posts.SingleOrDefault(x => x.Id == Id);
            return View(post);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(PostViewModel post)
        {
            _blogContext1.Posts.Add(post);
            _blogContext1.SaveChanges();
            return RedirectToAction("Post", new { post.Id });
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            List<PostViewModel> post = _blogContext1.Posts.Where(x => x.Id == Id).ToList();
            return View(post[0]);
        }

        [HttpPost]
        public ActionResult Edit(PostViewModel post)
        {
            var oldPost = _blogContext1.Posts.Where(x => x.Id == post.Id).FirstOrDefault();
            oldPost.Title = post.Title;
            oldPost.Content = post.Content;
            oldPost.Updated = DateTime.Now;
            _blogContext1.SaveChanges();

            return RedirectToAction("Post", new { post.Id });
        }

        public ActionResult Delete(int Id)
        {
            PostViewModel post = _blogContext1.Posts.SingleOrDefault(x => x.Id == Id);
            _blogContext1.Posts.Remove(post);
            _blogContext1.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}