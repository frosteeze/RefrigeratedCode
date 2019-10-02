using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RefrigeratedCode.Models;

namespace RefrigeratedCode.Data
{
    public interface IBlogPostRepository
    {
        List<BlogPost> GetBlogPosts(int skipNumOfBlogPosts);
        BlogPost GetBlogPost(int postID);

        void AddBlogPost(BlogPost post);
        Task<bool> SaveChangesAsync();
        int GetBlogPostCount();
    }
}
