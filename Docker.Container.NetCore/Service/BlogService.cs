using DOCKER.CONTAINER.NETCORE.Data;
using DOCKER.CONTAINER.NETCORE.Entity;
using Microsoft.EntityFrameworkCore;

namespace DOCKER.CONTAINER.NETCORE.Service
{

    public class BlogService : IBlogService
    {
        private readonly BlogDbContext _blogDbContext;

        public BlogService(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _blogDbContext.Blogs.AddAsync(blog);
            await _blogDbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var blog = await _blogDbContext.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            if (blog != null)
            {
                _blogDbContext.Blogs.Remove(blog);
                await _blogDbContext.SaveChangesAsync();
                id = blog.Id;
            }
            return id;
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogDbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogDbContext.Blogs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
            var existingBlog = await _blogDbContext.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            if (existingBlog != null)
            {
                existingBlog.Name = blog.Name;
                existingBlog.Description = blog.Description;
                existingBlog.Author = blog.Author;
                await _blogDbContext.SaveChangesAsync();
            }
            return existingBlog.Id;
        }
    }
}