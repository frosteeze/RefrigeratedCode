using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RefrigeratedCode.Models;

namespace RefrigeratedCode.Data
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private BlogPostDbContext _context;

        public BlogPostRepository(BlogPostDbContext context)
        {
            _context = context;
        }
        public List<BlogPost> GetBlogPosts(int skipNumOfBlogPosts = 0)
        {
            const int numOfBlogPostsInPage = 7;
            return _context.BlogPosts.OrderByDescending(o => o.PostedOn).Skip(skipNumOfBlogPosts).Take(numOfBlogPostsInPage).ToList();
        }

        public BlogPost GetBlogPost(int postID)
        {
            return _context.BlogPosts.Single(post => post.PostId == postID);
        }

        public void AddBlogPost(BlogPost post)
        {
            _context.Add(post);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public int GetBlogPostCount()
        {
            return _context.BlogPosts.ToList().OrderByDescending(o => o.PostedOn).Count();
        }
    }
}
