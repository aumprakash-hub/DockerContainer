using Microsoft.EntityFrameworkCore;
using DOCKER.CONTAINER.NETCORE.Entity;

namespace DOCKER.CONTAINER.NETCORE.Data{

    public class BlogDbContext: DbContext{

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; }

    }
}