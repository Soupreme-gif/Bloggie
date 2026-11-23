using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public void OnGet()
        {
            BlogPosts = _bloggieDbContext.BlogPosts.ToList();
        }
    }
}
