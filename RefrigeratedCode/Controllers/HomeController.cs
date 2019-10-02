using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RefrigeratedCode.Data;
using RefrigeratedCode.Models;

namespace RefrigeratedCode.Controllers
{
    public class HomeController : Controller
    {
        private IBlogPostRepository blogPostRepository;
        public HomeController(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Posts(int postID)
        {
            var post = blogPostRepository.GetBlogPost(postID);
            return View(post);
        }

        [HttpGet]
        public JsonResult GetPosts(int currentPostCount = 0)
        {
            return  Json(blogPostRepository.GetBlogPosts(currentPostCount));
        }
    }
}
