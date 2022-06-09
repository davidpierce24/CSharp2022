using System.ComponentModel.DataAnnotations;
namespace mvclecture.Models;
#pragma warning disable CS8618

public class User
{
    // validations go right above whatever we're trying to validate
    // can stack as many validations as we want
    [Required]
    [MinLength(2)]
    public string Name {get;set;}
    [Required]
    public string FavColor {get;set;}
    [Required]
    [Range(-1000,1000)]
    public int FavNumber {get;set;}
}