#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chefsNDishes.Models;

public class Chef
{
    [Key]
    public int ChefId {get; set;}
    [Required]
    public string FirstName {get; set;}
    [Required]
    public string LastName {get; set;}
    [Required]
    [DataType(DataType.Date)]
    [Past]
    [Over18]
    public DateTime DOB {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
    public List<Dish> ChefDishes {get; set;} = new List<Dish>();

}

public class PastAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (((DateTime)value) >= DateTime.Now)
        {
            return new ValidationResult("You can't be from the future!");
        }
        return ValidationResult.Success;
    }
}

public class Over18Attribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (DateTime.Now.Year - ((DateTime)value).Year < 18)
        {
            return new ValidationResult("Too Young!");
        }
        return ValidationResult.Success;
    }
}