using Microsoft.EntityFrameworkCore;
using WebStore.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.Entities.Orders;

namespace Webstore.DAL.Context
{
    public class WebStoreDB: IdentityDbContext<User, Role, string>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public WebStoreDB(DbContextOptions<WebStoreDB> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
        }
    }
}
