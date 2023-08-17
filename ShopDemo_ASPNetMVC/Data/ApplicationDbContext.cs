using Microsoft.EntityFrameworkCore;
using ShopDemo_ASPNetMVC.Models;

namespace ShopDemo_ASPNetMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Clothe> Clothes { get; set; }
        public DbSet<ClotheCategory> ClotheCategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clothe>().ToTable("Clothe");
            modelBuilder.Entity<ClotheCategory>().ToTable("ClotheCategory");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<ContactMessage>().ToTable("ContactMessage");
        }
    } 
}
