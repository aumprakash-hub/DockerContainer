using System.Reflection.Metadata;
using DOCKER.CONTAINER.NETCORE.Entity;
using DOCKER.CONTAINER.NETCORE.Service;
using Microsoft.AspNetCore.Mvc;

namespace DOCKER.CONTAINER.NETCORE.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _blogService.GetAllAsync();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null) { return NotFound(); }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            var createdBlog = await _blogService.CreateAsync(blog);
            return Ok(createdBlog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Blog blog)
        {
            var updatedBlog = await _blogService.UpdateAsync(id, blog);
            if (updatedBlog == 0) return NotFound();
            return Ok(updatedBlog);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _blogService.DeleteAsync(id);
            if (blog == 0) return NotFound();
            return Ok(blog);
        }
    }
}