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
        void CreateBlogPost(BlogPost blogPost);
        void CreateAnyBlogPost();
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

        public void CreateBlogPost(BlogPost blogPost)
        {
            using (var session = _documentStore.OpenSession())
            {
                blogPost.Published = DateTime.Today;
                session.Store(blogPost);
                session.SaveChanges();
            }
        }

        public void CreateAnyBlogPost()
        {
            using (var session = _documentStore.OpenSession())
            {
                CreateBlogPost(
                    session,
                    "BlogPosts/1",
                    "Roodebeek",
                    "<p><p><a href=\"http://i.imgur.com/Ttd0aJK.jpg\" data-toggle=\"lightbox\"><img src=\"http://i.imgur.com/JR0JScQ.jpg\" class=\"img-responsive\"></a></p></p>",
                    new DateTime(2014, 08, 23)
                    );

                
                CreateBlogPost(
                    session,
                    "BlogPosts/2",
                    "Erasmus bridge, Rotterdam",
                    "<p><p><a href=\"http://i.imgur.com/yqH9qyU.jpg\" data-toggle=\"lightbox\"><img src=\"http://i.imgur.com/yqH9qyU.jpg\" class=\"img-responsive\"></a></p></p>",
                    new DateTime(2014, 08, 24)
                    );

                CreateBlogPost(
                    session,
                    "BlogPosts/3",
                    "A Vespa called Mojito",
                    "<p><p><a href=\"http://i.imgur.com/I4XgNQs.jpg\" data-toggle=\"lightbox\"><img src=\"http://i.imgur.com/I4XgNQs.jpg\" class=\"img-responsive\"></a></p></p>",
                    new DateTime(2014, 08, 19)
                );

                session.SaveChanges();
            }
        }

        private void CreateBlogPost(IDocumentSession session, string id, string title, string content, DateTime published)
        {
            var blogPost = new BlogPost() {Content = content, Id = id, Published = published, Title = title};
            session.Store(blogPost);
        }
    }
}
