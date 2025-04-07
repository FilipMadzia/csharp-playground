using System.ComponentModel.DataAnnotations;

namespace expenses_manager.Models;

public abstract class Entity
{
    [Key]
    public int Id { get; set; }
}