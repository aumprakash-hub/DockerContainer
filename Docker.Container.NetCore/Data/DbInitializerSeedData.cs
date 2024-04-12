using DOCKER.CONTAINER.NETCORE.Entity;

namespace DOCKER.CONTAINER.NETCORE.Data{
    public static class DbInitializerSeedData{
        public static void InitializeDatabase(BlogDbContext blogDbContext){
            if(blogDbContext.Blogs.Any()){return;}

            var blogOne = new Blog{
                Name = "C#",
                Author = "Aumprakash",
                Description = "C sharp is a good language"
            };

             var blogTwo = new Blog{
                Name = "Angular",
                Author = "Mitrabinda",
                Description = "Angular sharp is a good framework"
            };
            blogDbContext.Blogs.AddRangeAsync(blogOne, blogTwo);
            blogDbContext.SaveChangesAsync();
        }
    }
}