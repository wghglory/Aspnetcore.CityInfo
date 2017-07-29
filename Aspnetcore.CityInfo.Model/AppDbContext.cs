using Aspnetcore.CityInfo.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aspnetcore.CityInfo.Model
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
            Database.Migrate();  // same as `dotnet ef database update`
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            optionsBuilder.UseMySql("MysqlConnection");
//            base.OnConfiguring(optionsBuilder);
        }
    }
}
