using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

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
            try
            {
                //throw new Exception();

                await _blogPostRepository.UpdateAsync(BlogPost);

                var notification = new Notification
                {
                    Message = "Blog successfully deleted!",
                    Type = Enums.NotificationType.Success
                };

                //JsonSerializer is nessesary because "TempData" gets sent to another page as an Http request which can't pass complex objects like the notification variable above
                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Admin/Blogs/List");
            }
            catch(Exception ex)
            {
                var notification = new Notification
                {
                    Message = "Something went wrong!",
                    Type = Enums.NotificationType.Error
                };

                //JsonSerializer is nessesary because "TempData" gets sent to another page as an Http request which can't pass complex objects like the notification variable above
                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Admin/Blogs/List");
            }
            

            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {

            var deletingBlog = await _blogPostRepository.DeleteAsync(BlogPost.Id);
            if (deletingBlog == true)
            {

                var notification = new Notification
                {
                    Message = "Blog successfully deleted!",
                    Type = Enums.NotificationType.Success
                };

                //JsonSerializer is nessesary because "TempData" gets sent to another page as an Http request which can't pass complex objects like the notification variable above
                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Admin/Blogs/List");
            }
          
            return Page();
          
        }
    }
}
