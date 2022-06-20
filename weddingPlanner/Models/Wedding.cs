#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weddingPlanner.Models;

public class Wedding
{
    [Key]
    public int WeddingId {get; set;}
    [Required]
    [MinLength(2)]
    public string Spouse1 {get; set;}
    [Required]
    [MinLength(2)]
    public string Spouse2 {get; set;}
    [Required]
    [Future]
    public DateTime Date {get; set;}
    [Required]
    public string Address {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
    public List<Connection> Attendees {get; set;} = new List<Connection>();
}

// custom validation to ensure date is in the future
public class FutureAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (((DateTime)value) <= DateTime.Now)
        {
            return new ValidationResult("Did you already get married?");
        }
        return ValidationResult.Success;
    }
}