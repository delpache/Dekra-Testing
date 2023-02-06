using Dekra.Domain.DTO;
using Dekra.Domain.Entities;

namespace Dekra.Domain.Repositories;

public interface IVehicleRepository
{
    public List<Vehicle> GetAllVehicle();
    public Vehicle GetVehicleById(int id);
    public string GetMouvementLogistique(DTOMouvementVehicle dTOMouvementVehicle);
}
