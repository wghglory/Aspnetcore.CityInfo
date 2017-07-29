using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

/* Startup, Program in this project is just for .net core tooling,
 * Run dotnet ef migrations add <name>
 * dotnet ef database update
 
 * Database seed, DI for Repository and AppDbContext are still in main project
*/
namespace Aspnetcore.CityInfo.Model
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(
                o => o.UseMySql(Configuration.GetConnectionString("MysqlConnection")));
        }

    }
}