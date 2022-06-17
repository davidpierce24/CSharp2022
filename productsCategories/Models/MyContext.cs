#pragma warning disable CS8618
    using Microsoft.EntityFrameworkCore;
    namespace productsCategories.Models;

    public class MyContext : DbContext 
    { 
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products {get; set;} 
        public DbSet<Category> Categories {get; set;} 
        public DbSet<Group> Groups {get; set;} 
    }