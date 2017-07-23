# Asp.net Core Api

When all code is ready, we first run `dotnet ef migrations add Initial` to generate Migration. Usually after this we need to run `dotnet ef database update` so we will have a database with _EFMigrationHistory and other empty tables. But in this project we don't need run `dotnet ef database update` command since we explictly call `Database.Migrate()` in DbContext:

```csharp
using Microsoft.EntityFrameworkCore;

namespace Aspnetcore.CityInfo.Api.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
            Database.Migrate();  // same as `dotnet ef database update`
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }
    }
}
```

## Api testing

import test/City.postman.json to postman and run test.