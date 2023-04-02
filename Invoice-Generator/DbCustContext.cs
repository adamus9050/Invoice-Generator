using Invoice_Generator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Invoice_Generator
{
    public class DbCustContext :  IdentityDbContext<UserModel> //DbContext 
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
