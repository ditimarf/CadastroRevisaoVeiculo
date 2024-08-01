using Backend.Repository;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace TesteBackend
{
    public class TesteGolApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<AppDBContext>));

                services.AddDbContext<AppDBContext>(options =>
                    options.UseInMemoryDatabase("CatalogoDatabase", root));
            });

            return base.CreateHost(builder);
        }
    }
}

