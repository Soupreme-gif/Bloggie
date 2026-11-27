using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository _blogPostRepository;

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        public EditModel(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task OnGet(Guid id)
        {

            BlogPost = await  _blogPostRepository.GetAsync(id);

        }

        public async Task<IActionResult> OnPostEdit()
        {
            await _blogPostRepository.UpdateAsync(BlogPost);
            ViewData["MessageDescription"] = "Record was successfully saved!";

            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {

            var deletingBlog = await _blogPostRepository.DeleteAsync(BlogPost.Id);
            if(deletingBlog = true)
            {
                return RedirectToPage("/Admin/Blogs/List");
            }
          
            return Page();
          
        }
    }
}
