using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Models
{
    public class APIDBContextFactory : IDesignTimeDbContextFactory<APIDBContext>
    {
        public APIDBContext CreateDbContext(string[] args)
        {
            // Build configuration to read from appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Get connection string
            var connectionString = configuration.GetConnectionString("Devconnection");

            var optionsBuilder = new DbContextOptionsBuilder<APIDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new APIDBContext(optionsBuilder.Options);
        }
    }
}
