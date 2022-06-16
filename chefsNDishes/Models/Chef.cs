#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chefsNDishes.Models;

public class Chef
{
    [Key]
    public int ChefId {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public DateTime DOB {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
    public List<Dish> ChefDishes {get; set;} = new List<Dish>();

}