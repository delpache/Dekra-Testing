using Dekra.Domain.Entities;

namespace Dekra.Domain.DTO;

public class DTOMouvementVehicle
{
    public int VehicleId { get; }
    public int ParcId { get; }
    public DateTime DateMouvement { get; }
    public TypeMouvement TypeDuMouvement { get; }

}
