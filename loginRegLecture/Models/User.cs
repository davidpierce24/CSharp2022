#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// this is for the not mapped
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace loginRegLecture.Models;

public class Users
{
    [Key]
    public int UserId { get; set;}
    [Required]
    public string Username { get; set; }
    [EmailAddress]
    [Required]
    public string Email {get; set;}
    [Required]
    [MinLength(8)]
    public string Password {get; set;}
    // anything under not mapped will not go into the db
    [NotMapped]
    [Compare("Password")]
    public string PassConfirm {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
}