using Dekra.Domain.Entities.Base;

namespace Dekra.Domain.Entities;

public class Mouvement : Entity
{
    public DateTime DateMouvement { get; set; }
    public TypeMouvement TypeMouvement { get; set; }

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }

    public int ParcId { get; set; }
    public Parc Parc { get; set; }

}
