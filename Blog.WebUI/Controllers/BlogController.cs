using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Blog.ViewModels;
using Blog.BLL;


namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        private BlogSerrvice _blogService;

        public BlogController()
        {
            BlogSerrvice blogService = new BlogSerrvice();
        }
        public ActionResult Index()
        {
            return View(_blogService.GetAllPosts());
        }

        [ChildActionOnly]
        public ActionResult PostInfo(PostViewModel post)
        {
            return PartialView("_PostInfo", post);
        }

        public ActionResult Post(int Id)
        {
            return View(_blogService.GetPost(Id));
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
            _blogService.NewPost(post);
            return RedirectToAction("Post", new { post.Id });
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            return View(_blogService.GetPost(Id));
        }

        [HttpPost]
        public ActionResult Edit(PostViewModel post)
        {
            _blogService.EditPost(post);
            return RedirectToAction("Post", new { post.Id });
        }

        public ActionResult Delete(int Id)
        {
            _blogService.DeletePost(Id);
            return RedirectToAction("Index");
        }

    }
}