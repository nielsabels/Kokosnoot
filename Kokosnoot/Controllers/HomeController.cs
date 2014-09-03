using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kokosnoot.Services;

namespace Kokosnoot.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogPostService _blogPostService;

        public HomeController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public ActionResult Index()
        {
            var blogPost = _blogPostService.GetBlogPosts();

            return View(blogPost);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}