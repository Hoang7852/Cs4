using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Asm_Ph21208.Models
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext() { }
        public ShoppingDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-CE2FRLB\SQLEXPRESS;Initial Catalog=huhu;Persist Security Info=True;User ID=ph21208;Password=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
