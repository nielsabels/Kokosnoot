using System.Net;
using Kokosnoot.Models;
using Kokosnoot.Services;
using Raven.Client.Embedded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Database.Impl.Clustering;
using Raven.Imports.Newtonsoft.Json;

namespace Kokosnoot.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        // GET: BlogPost
        public ActionResult Index()
        {
            return View();
        }

        // GET: BlogPost/Details/5
        public ActionResult Details(int id)
        {
            ActionResult actionResult = null;
            BlogPost blogPost = null;

            try
            {
                blogPost = _blogPostService.GetBlogPost(id);
                if (blogPost != null)
                    actionResult = View(blogPost);
            }
            catch (Exception)
            {
                actionResult = new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            if (blogPost == null)
                actionResult = new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return actionResult;
        }

        // GET: BlogPost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPost/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(BlogPost blogPost)
        {
            ActionResult actionResult = null;
            
            try
            {
                blogPost = _blogPostService.CreateBlogPost(blogPost);    
                actionResult = RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                actionResult = new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            return actionResult;
        }

        // GET: BlogPost/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogPost/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogPost/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogPost/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
