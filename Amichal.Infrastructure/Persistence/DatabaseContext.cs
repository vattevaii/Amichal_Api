using Amichal.Domain.Entities;
using Amichal.Domain.Entities.UserRoles;
using Microsoft.EntityFrameworkCore;

namespace Amichal.Infrastructure.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                .HasDiscriminator<int>("userrole")
                .HasValue<Customer>(0)
                .HasValue<Seller>(2)
                .HasValue<GroupAdmin>(1)
                .HasValue<Admin>(10)
                .HasValue<User>(100);

        }
        //public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Cart> cartProducts { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Seller> sellers { get; set; }
        public DbSet<GroupAdmin> groupAdmins { get; set; }
        public DbSet<Admin> admins { get; set; }
    }
}