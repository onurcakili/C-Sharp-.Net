using Microsoft.EntityFrameworkCore;

namespace MicroServices.Model
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext>options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = Configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);  
        }
    }
}
