using System.Security.Cryptography.X509Certificates;
using Kokosnoot.Models;
using Kokosnoot.Services.Extensions;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kokosnoot.Services
{
    public interface IBlogPostService
    {
        IList<BlogPost> GetBlogPosts();
        BlogPost GetBlogPost(int id);
        BlogPost CreateBlogPost(BlogPost blogPost);
    }

    public class BlogPostService : IBlogPostService
    {
        private readonly IDocumentStore _documentStore;

        public BlogPostService(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public IList<BlogPost> GetBlogPosts()
        {
            using (var session = _documentStore.OpenSession())
            {
                var blogPosts = session.Query<BlogPost>().OrderByDescending(blogPost => blogPost.Published).ToList();
                return blogPosts;
            }
        }

        public BlogPost GetBlogPost(int id)
        {
            using (var session = _documentStore.OpenSession())
            {
                var fullyQualifiedId = session.GetStringId<BlogPost>(id);
                var blogPost = session.Load<BlogPost>(fullyQualifiedId);
                return blogPost;
            }
        }

        public BlogPost CreateBlogPost(BlogPost blogPost)
        {
            using (var session = _documentStore.OpenSession())
            {
                blogPost.Published = DateTime.Today;
                session.Store(blogPost);
                session.SaveChanges();
            }
            return blogPost;
        }
    }
}
