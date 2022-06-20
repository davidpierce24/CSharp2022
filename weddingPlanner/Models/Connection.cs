#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weddingPlanner.Models;

public class Connection
{
    [Key]
    public int ConnectionId {get; set;}
    public int WeddingId {get; set;}
    public Wedding? Wedding {get; set;}
    public int UserId {get; set;}
    public User? User {get; set;}
}