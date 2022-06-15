#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginRegister.Models;

public class User
{
    [Key]
    public int UserId {get; set;}
    [Required]
    [MinLength(2)]
    public string FirstName {get; set;}
    [Required]
    [MinLength(2)]
    public string LastName {get; set;}
    [Required]
    public string Username {get; set;}
    [Required]
    [EmailAddress]
    public string Email {get; set;}
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string Password {get; set;}
    [NotMapped]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
}