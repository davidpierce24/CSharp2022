#pragma warning disable CS8618
    using Microsoft.EntityFrameworkCore;
    namespace productsCategories.Models;

    public class MyContext : DbContext 
    { 
        public MyContext(DbContextOptions options) : base(options) { }
        // public DbSet<ClassName> ClassesNames {get; set;} 
    }