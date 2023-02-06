using Dekra.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Dekra.Domain.Entities;

public class Vehicle : Entity
{
    [Required, MinLength(17), MaxLength(17)]
    public string Vin { get; set; }

    public Color Couleur { get; set; }

    public DateTime DateImmatriculation { get; set; }


    public List<Parc> Parcs { get; set; } = new List<Parc>();
}
