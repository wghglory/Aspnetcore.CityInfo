using Aspnetcore.CityInfo.Api.Entities;
using Aspnetcore.CityInfo.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;

namespace Aspnetcore.CityInfo.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }


        public void ConfigureServices(IServiceCollection services)
        {
//            services.AddMvc().AddMvcOptions(o => o.OutputFormatters.Add(
//                new XmlDataContractSerializerOutputFormatter()));

            services.AddMvc().AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

#if DEBUG
            services.AddTransient<IMailService, LocalMailService>(serviceProvider =>
            {
                string mailFrom = Configuration["mailSettings:mailFromAddress"];
                string mailTo = Configuration.GetValue<string>("mailSettings:mailToAddress");
                return new LocalMailService(mailFrom, mailTo);
            });
#else
            services.AddTransient<IMailService, CloudMailService>(serviceProvider =>
            {
                string mailFrom = Configuration["mailSettings:mailFromAddress"];
                string mailTo = Configuration.GetValue<string>("mailSettings:mailToAddress");
                return new CloudMailService(mailFrom, mailTo);
            });
#endif
            services.AddDbContext<AppDbContext>(
                o => o.UseMySql(Configuration.GetConnectionString("MysqlConnection")));

            services.AddScoped<ICityInfoRepository, CityInfoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            AppDbContext dbContext
        )
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            loggerFactory.AddProvider(new NLog.Extensions.Logging.NLogLoggerProvider());
            loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }


            app.UseStatusCodePages();

            app.UseMvc();

//            dbContext.Seed();   // method 1: extend DbContext
            DbInitializer.Seed(app); // method 2: write a static class
        }
    }
}