using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RefrigeratedCode.Data;
using RefrigeratedCode.Models;

namespace RefrigeratedCode.Controllers
{
    public class SubmissionController : Controller
    {
        private IBlogPostRepository blogPostRepository;
        public SubmissionController(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Submit([FromBody] BlogPost post)
        {
            blogPostRepository.AddBlogPost(post);

            if (await blogPostRepository.SaveChangesAsync())
            {
                return RedirectToAction( nameof(HomeController.Index), "Home");
            }

            return BadRequest("Failed to save blog post");
        }
    }
}
