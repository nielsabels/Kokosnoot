﻿using Kokosnoot.Models;
using Kokosnoot.Services;
using Raven.Client.Embedded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kokosnoot.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly BlogPostService _blogPostService;

        public BlogPostController(BlogPostService blogPostService)
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
            return View();
        }

        // GET: BlogPost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPost/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                _blogPostService.CreateAnyBlogPost();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
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
