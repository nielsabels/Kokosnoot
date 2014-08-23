using Kokosnoot.Models;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kokosnoot.Services
{
    public class BlogPostService
    {
        private readonly IDocumentStore _documentStore;

        public BlogPostService(IDocumentStore documentStore)
        {
            _documentStore = documentStore; 
        }

        public void CreateAnyBlogPost()
        {
            using (var session = _documentStore.OpenSession())
            {
                var blogPostId = "BlogPosts/1";
                var blogPost = session.Load<BlogPost>(blogPostId);

                if (blogPost == null)
                {
                    blogPost = new BlogPost();
                    blogPost.Id = blogPostId;
                    blogPost.Title = "Titel";

                    session.Store(blogPost);
                    session.SaveChanges();
                }
            }
        }
    }
}
