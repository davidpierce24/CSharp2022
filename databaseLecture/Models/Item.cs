#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace databaseLecture.Models;

public class Item
{
    // we need an ID
    // name the same as class with Id at the end - model + Id
    [Key]
    public int ItemId {get; set;}
    [Required]
    public string Name {get; set;}
    [Required]
    [MinLength(10)]
    public string Description {get; set;}
    // we always include a created at and updated at because it's a good practice
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

}