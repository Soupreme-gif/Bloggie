using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly BloggieDbContext _bloggieDbContext;

        public List<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();

        public ListModel(BloggieDbContext bloggieDbContext)
        {
            _bloggieDbContext = bloggieDbContext;
        }

        public async Task OnGet()
        {
            var messageDescription = (string)TempData["MessageDescription"];

            if (!string.IsNullOrWhiteSpace(messageDescription))
            {
                ViewData["MessageDescription"] = messageDescription;
            }

            BlogPosts = (await _bloggieDbContext.BlogPosts.ToListAsync())?.ToList();
        }

    }
}
