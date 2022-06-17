#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace manyToManyLecture.Models;

public class CastList
{
    [Key]
    public int CastListId {get; set;}
    // connection to actor table
    public int ActorId {get; set;}
    public Actor? Actor {get; set;}
    // connection to movie table
    public int MovieId {get; set;}
    public Movie? Movie {get; set;}
    
}