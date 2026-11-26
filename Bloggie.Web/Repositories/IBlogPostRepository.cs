using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
    // This Interface is used to create central point for all database operations to minimize the amount of changes required if the database got updated.
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<BlogPost> GetAsync(Guid id);
        Task<BlogPost> AddAsync(BlogPost blogPost);
        Task<BlogPost> UpdateAsync(BlogPost blogPost);
        Task<bool> DeleteAsync(Guid id);

    }
}
