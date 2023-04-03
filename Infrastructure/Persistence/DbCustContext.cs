using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class DbCustContext : DbContext //IdentityDbContext<UserModel>  
    {
        public DbCustContext(DbContextOptions<DbCustContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Material> Materials { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
