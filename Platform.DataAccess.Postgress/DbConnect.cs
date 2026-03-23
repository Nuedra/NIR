using Microsoft.EntityFrameworkCore;

namespace Platform.DataAccess.Postgress
{

    public static class PlatformDatabase
    {

        public static PlatformDbContext Connect(string connectionString)
        {
            var options = new DbContextOptionsBuilder<PlatformDbContext>()
                .UseNpgsql(connectionString)
                .Options;

            return new PlatformDbContext(options);
        }
    }
}
