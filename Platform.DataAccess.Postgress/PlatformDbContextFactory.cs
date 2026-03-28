using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Platform.DataAccess.Postgress
{
    public sealed class PlatformDbContextFactory : IDesignTimeDbContextFactory<PlatformDbContext>
    {
        public PlatformDbContext CreateDbContext(string[] args)
        {
            var connectionString =
                Environment.GetEnvironmentVariable("PLATFORM_DB_CONNECTION")
                ?? "Host=localhost;Port=5432;Database=platform;Username=postgres;Password=pass";

            var options = new DbContextOptionsBuilder<PlatformDbContext>()
                .UseNpgsql(connectionString)
                .Options;

            return new PlatformDbContext(options);
        }
    }
}
