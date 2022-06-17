#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace manyToManyLecture.Models;

public class Actor
{
    [Key]
    public int MovieId {get; set;}
    public string Name {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
    public List<CastList> MoviesActerIn {get; set;} = new List<CastList>();
}