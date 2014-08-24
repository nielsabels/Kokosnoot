using System.Security.Cryptography.X509Certificates;
using Kokosnoot.Models;
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
        BlogPost GetBlogPost(string id);
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
                var blogPosts = session.Query<BlogPost>().OrderBy(blogPost => blogPost.Published).ToList();
                return blogPosts;
            }   
        }

        public BlogPost GetBlogPost(string id)
        {
            using (var session = _documentStore.OpenSession())
            {
                var blogPost = session.Load<BlogPost>(id);
                return blogPost;
            }
        }

        public void CreateAnyBlogPost()
        {
            using (var session = _documentStore.OpenSession())
            {
                const string blogPostId = "BlogPosts/1";

                createBlogPost(
                    session,
                    blogPostId,
                    "Lorem ipsum dolor sit amet",
                    "<p><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce viverra interdum ipsum at ornare. Nullam ultricies eros odio, sed laoreet eros interdum et. Etiam pellentesque metus eget magna tempor fringilla. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi ultricies ligula id metus pulvinar vestibulum. Vestibulum elit elit, tincidunt quis facilisis at, suscipit vel felis. In in nulla tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Praesent ipsum nibh, fringilla non magna sit amet, tristique mollis sem. Donec vel mollis purus. Cras consectetur sem eros, sit amet molestie sapien consectetur ut.</p><p>In fringilla sapien non blandit tempor. Fusce commodo ipsum vel mi fermentum vulputate. Morbi ut nisi ac neque bibendum ultrices. Aliquam et sem augue. Ut facilisis, quam quis imperdiet suscipit, ex tortor vestibulum diam, id tincidunt massa nisl egestas nisl. Etiam aliquet consectetur viverra. Nam sed urna sit amet dolor condimentum dignissim a in nunc. Ut porta sem nulla, quis gravida lacus facilisis at. Praesent in elementum est. Proin cursus ante sit amet suscipit vehicula. Mauris dignissim vitae nibh ut tristique. Donec eu laoreet ipsum.</p><p><a href=\"http://i.imgur.com/7gCkZlU.jpg\" data-toggle=\"lightbox\"><img src=\"http://i.imgur.com/7gCkZlU.jpg\" class=\"img-responsive\"></a></p></p>",
                    new DateTime(2014, 08, 24)
                    );

                
                createBlogPost(
                    session,
                    blogPostId,
                    "Neque porro quisquam est qui dolorem",
                    "<p><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque auctor egestas velit sed efficitur. Proin dignissim non ante non porta. Nullam faucibus quis elit id luctus. Fusce vehicula pellentesque massa vitae maximus. Nullam porttitor, lectus ac euismod semper, enim eros pretium nisi, et imperdiet dolor quam vitae metus.</p><p><a href=\"http://i.imgur.com/yqH9qyU.jpg\" data-toggle=\"lightbox\"><img src=\"http://i.imgur.com/yqH9qyU.jpg\" class=\"img-responsive\"></a></p></p>",
                    new DateTime(2014, 08, 23)
                    );

                session.SaveChanges();
            }
        }

        private void createBlogPost(IDocumentSession session, string id, string title, string content, DateTime published)
        {
            var blogPost = new BlogPost() {Content = content, Id = id, Published = published, Title = title};
            session.Store(blogPost);
        }
    }
}
