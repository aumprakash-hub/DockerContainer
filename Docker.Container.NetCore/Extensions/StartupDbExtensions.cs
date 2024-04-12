using DOCKER.CONTAINER.NETCORE.Data;

namespace DOCKER.CONTAINER.NETCORE.Extensions{

    public static class StartupDbExtensions{
        public static async void CreateDbIfNotExists(this IHost host){
            using var scope = host.Services.CreateAsyncScope();
            var services = scope.ServiceProvider;

            var blogContext = services.GetRequiredService<BlogDbContext>();
            blogContext.Database.EnsureCreated();
            


            DbInitializerSeedData.InitializeDatabase(blogContext);
        }
    }
}