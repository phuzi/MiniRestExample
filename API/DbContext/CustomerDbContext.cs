using Common;
using Microsoft.EntityFrameworkCore;

namespace API.DbContext
{
    public class CustomerDbContext : Microsoft.EntityFrameworkCore.DbContext, ICustomerDbContext
    {
        private readonly IConfiguration _configuration;

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Customer>? Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("CustomerDb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerRef);

            modelBuilder.Entity<Customer>()
                .Property(x => x.CustomerRef)
                .ValueGeneratedNever();
        }
    }
}
