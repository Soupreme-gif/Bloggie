using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {

        private readonly BloggieDbContext _bloggieDbContext;
        [BindProperty]
        public BlogPost BlogPost { get; set; }

        public EditModel(BloggieDbContext bloggieDbContext)
        {
            _bloggieDbContext = bloggieDbContext;
        }

        public void OnGet(Guid id)
        {

          BlogPost = _bloggieDbContext.BlogPosts.Find(id);

        }

        public IActionResult OnPostEdit()
        {
            var existingBlogPost = _bloggieDbContext.BlogPosts.Find(BlogPost.Id);

            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = BlogPost.Heading;
                existingBlogPost.PageTitle = BlogPost.PageTitle;
                existingBlogPost.Content = BlogPost.Content;
                existingBlogPost.ShortDescription = BlogPost.ShortDescription;
                existingBlogPost.FeaturedImageUrl = BlogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle = BlogPost.UrlHandle;
                existingBlogPost.PublishedDate = BlogPost.PublishedDate;
                existingBlogPost.Author = BlogPost.Author;
                existingBlogPost.Visible = BlogPost.Visible;
            }

            _bloggieDbContext.SaveChanges();
            return RedirectToPage("/Admin/Blogs/List");
        }

        public IActionResult OnPostDelete()
        {
            var existingBlogPost = _bloggieDbContext.BlogPosts.Find(BlogPost.Id);

            if(existingBlogPost != null)
            {
                _bloggieDbContext.Remove(existingBlogPost);
                _bloggieDbContext.SaveChanges();
                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();

        }
    }
}
