#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace chefsNDishes.Models;

public class MyContext : DbContext 
{ 
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<Chef> Chefs {get; set;} 
    public DbSet<Dish> Dishes {get; set;} 
}

// add more of this line (public DbSet<ClassName> ClassesNames {get; set;} ) whenever theres a new table needed in db