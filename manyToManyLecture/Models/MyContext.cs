#pragma warning disable CS8618
    using Microsoft.EntityFrameworkCore;
    namespace manyToManyLecture.Models;

    public class MyContext : DbContext 
    { 
        public MyContext(DbContextOptions options) : base(options) { }
        // public DbSet<ClassName> ClassesNames {get; set;}
    }

    // add more of this line (public DbSet<ClassName> ClassesNames {get; set;} ) whenever theres a new table needed in db