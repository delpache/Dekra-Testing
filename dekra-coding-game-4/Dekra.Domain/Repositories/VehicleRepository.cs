using Dekra.Domain.DTO;
using Dekra.Domain.Entities;
using System.Collections.Generic;

namespace Dekra.Domain.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private List<Vehicle> _vehicles;
    private List<Mouvement> _mouvements;
    private List<Parc> _parcs;

    public VehicleRepository(List<Vehicle> vehicles, List<Mouvement> mouvements, List<Parc> parcs)
    {
        _vehicles = vehicles;
        _mouvements = mouvements;
        _parcs = parcs;
    }
    public List<Vehicle> GetAllVehicle()
    {
        return _vehicles.Select(x => x).ToList();
    }

    public string GetMouvementLogistique(DTOMouvementVehicle dTOMouvementVehicle)
    {
        Vehicle vehicle = GetVehicleById(dTOMouvementVehicle.VehicleId);
        Parc? parc = _parcs.Where(x => x.Id == dTOMouvementVehicle.ParcId).FirstOrDefault();
        if (dTOMouvementVehicle.TypeDuMouvement == TypeMouvement.Sortie)
        {
            var vehicleEntree = _mouvements.Where(x =>
                x.VehicleId == dTOMouvementVehicle.VehicleId &&
                x.ParcId == dTOMouvementVehicle.ParcId && x.TypeMouvement == TypeMouvement.Entree).Count();
            if (vehicleEntree > 0)
            {

                return $" Le vehicule {vehicle.Vin} Immatriclation {vehicle.DateImmatriculation} est sorti du parc {parc.Name} " +
                    $"le {dTOMouvementVehicle.DateMouvement}";
            }
            else
            {
                return $"Le vehicule VIN {vehicle.Vin} n'est jamais entré dans ce Parc ";
            }
        }
        else
        {
            _mouvements.Add(new Mouvement()
            {
                DateMouvement = dTOMouvementVehicle.DateMouvement,
                ParcId = dTOMouvementVehicle.ParcId,
                VehicleId = dTOMouvementVehicle.VehicleId,
                Vehicle = vehicle,
                Parc = parc,
                TypeMouvement = TypeMouvement.Entree
            });

            return $"Le vehicule {vehicle.Vin} Immatriclation {vehicle.DateImmatriculation} est entré dans le parc {parc.Name} " +
                $"à la date du {dTOMouvementVehicle.DateMouvement}";
        }
    }

    public Vehicle GetVehicleById(int id)
    {
        return _vehicles.Where(x => x.Id == id).FirstOrDefault();
    }
}
