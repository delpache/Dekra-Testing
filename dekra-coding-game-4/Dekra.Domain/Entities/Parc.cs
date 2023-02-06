using Dekra.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Dekra.Domain.Entities;

public class Parc : Entity
{
    [Required]
    public string Name { get; set; }
    public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
