#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
namespace oneToManyLecture.Models;

public class Owner
{
    [Key]
    public int OwnerId {get; set;}
    public string Name {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
}