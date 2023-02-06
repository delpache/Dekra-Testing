namespace DekraVehicle;

public class Program
{
    public static class Constantes
    {
        public static readonly string[] PROPERTIES_WEIGHT_ASCENDING_ORDER = {
            "MakeTechnicalId",
            "ModelTechnicalId",
            "ModelYear",
            "Generation",
            "BodyTypeTechnicalId",
            "VersionTechnicalId"
        };
    }
    public static void Main(string[] args)
    {
        // Déclaration des DTOs Vehicle Range
        var vehicleRangeList = new List<VehicleRange>()
        {
            new VehicleRange()
            {
                TechnicalId = Guid.NewGuid(),
                MakeTechnicalId = Guid.NewGuid(),
                ModelTechnicalId = Guid.NewGuid(),
                BodyTypeTechnicalId = Guid.NewGuid(),
                VersionTechnicalId = Guid.NewGuid(),
                Generation = "Generation 1 2023",
                ModelYear = 2023,
                RangeName = "Peugeot",
            },
            new VehicleRange()
            {
                TechnicalId = Guid.NewGuid(),
                MakeTechnicalId = Guid.NewGuid(),
                ModelTechnicalId = Guid.NewGuid(),
                BodyTypeTechnicalId = Guid.NewGuid(),
                VersionTechnicalId = Guid.NewGuid(),
                Generation = "Generation 3 2023",
                ModelYear = 2023,
                RangeName = "Peugeot",
            },
            new VehicleRange()
            {
                TechnicalId = Guid.NewGuid(),
                MakeTechnicalId = Guid.NewGuid(),
                ModelTechnicalId = Guid.NewGuid(),
                BodyTypeTechnicalId = Guid.NewGuid(),
                VersionTechnicalId = Guid.NewGuid(),
                Generation = "Generation 2 2023",
                ModelYear = 2023,
                RangeName = "Renault",
            },
            new VehicleRange()
            {
                TechnicalId = Guid.NewGuid(),
                MakeTechnicalId = Guid.NewGuid(),
                ModelTechnicalId = Guid.NewGuid(),
                BodyTypeTechnicalId = Guid.NewGuid(),
                VersionTechnicalId = Guid.NewGuid(),
                Generation = "Generation 1 2022",
                ModelYear = 2022,
                RangeName = "BMW",
            },
            new VehicleRange()
            {
                TechnicalId = Guid.NewGuid(),
                MakeTechnicalId = Guid.NewGuid(),
                ModelTechnicalId = Guid.NewGuid(),
                BodyTypeTechnicalId = Guid.NewGuid(),
                VersionTechnicalId = Guid.NewGuid(),
                Generation = "Generation 2 2022",
                ModelYear = 2022,
                RangeName = "Mercedes",
            },
            new VehicleRange()
            {
                TechnicalId = Guid.NewGuid(),
                MakeTechnicalId = Guid.NewGuid(),
                ModelTechnicalId = Guid.NewGuid(),
                BodyTypeTechnicalId = Guid.NewGuid(),
                VersionTechnicalId = Guid.NewGuid(),
                Generation = "Generation 2021",
                ModelYear = 2021,
                RangeName = "Audi",
            },
            new VehicleRange()
            {
                TechnicalId = Guid.NewGuid(),
                MakeTechnicalId = Guid.NewGuid(),
                ModelTechnicalId = Guid.NewGuid(),
                BodyTypeTechnicalId = Guid.NewGuid(),
                VersionTechnicalId = Guid.NewGuid(),
                Generation = "Generation 2020",
                ModelYear = 2020,
                RangeName = "Toyota",
            }
        };

        // Déclaration du DTO Vehicle
        var vehicle = new Vehicle()
        {
            TechnicalId = Guid.NewGuid(),
            MakeTechnicalId = Guid.NewGuid(),
            ModelTechnicalId = Guid.NewGuid(),
            BodyTypeTechnicalId = Guid.NewGuid(),
            VersionTechnicalId = Guid.NewGuid(),
            Generation = "Generation 1 2023",
            ModelYear = 2023,
        };

        var result = getMatchingVehicleRange(vehicleRangeList, vehicle);
    }

    /// <summary>
    /// Fonction permettant de retourner la liste
    /// des VehicleRange avec leur score ordonné du plus grand au plus petit
    /// </summary>
    /// <param name="vehicleRanges"></param>
    /// <param name="vehicle"></param>
    /// <returns></returns>
    public static VehicleRangeMatch getMatchingVehicleRange(List<VehicleRange> vehicleRanges, Vehicle vehicle)
    {
        var vehicleRangeMatch = new List<VehicleRangeMatch>();

        foreach (var vehicleRange in vehicleRanges)
        {
            var myScrore = getVehicleRangeMatchScore(vehicleRange, vehicle);
            if (myScrore > 0)
            {
                var newVehiculeMatch = new VehicleRangeMatch()
                {
                    TechnicalId = vehicleRange.TechnicalId,
                    MakeTechnicalId = vehicleRange.MakeTechnicalId,
                    ModelTechnicalId = vehicleRange.ModelTechnicalId,
                    BodyTypeTechnicalId = vehicleRange.BodyTypeTechnicalId,
                    VersionTechnicalId = vehicleRange.VersionTechnicalId,
                    Generation = vehicleRange.Generation,
                    ModelYear = vehicleRange.ModelYear,
                    RangeName = vehicleRange.RangeName,
                    Score = myScrore
                };

                vehicleRangeMatch.Add(newVehiculeMatch);
            }
        }

        return vehicleRangeMatch.OrderByDescending(x => x.Score).FirstOrDefault();
    }

    //private void filterAndScoreVehicleRangePerVehicle()

    /// <summary>
    /// Fonction permettant de retourner le Score en fonction du Vehicle
    /// </summary>
    /// <param name="vehicleRange"></param>
    /// <param name="vehicle"></param>
    /// <returns></returns>
    private static int getVehicleRangeMatchScore(VehicleRange vehicleRange, Vehicle vehicle)
    {
        int score = 0;

        for (int i = Constantes.PROPERTIES_WEIGHT_ASCENDING_ORDER.Length - 1; i >= 0; i--)
        {
            var propertyKey = Constantes.PROPERTIES_WEIGHT_ASCENDING_ORDER[i];
            var vehicleRangeProperty = vehicleRange.GetType().GetProperty(propertyKey).GetValue(vehicleRange);
            var vehicleProperty = vehicle.GetType().GetProperty(propertyKey).GetValue(vehicle);
            if (vehicleRangeProperty != null)
            {
                if (vehicleProperty != null && (vehicleRangeProperty.Equals(vehicleProperty)))
                {
                    if (score == 0)
                    {
                        score = i + 1;
                    }
                }
            }
        }
        return score;
    }
}