namespace DekraVehicle;

public class Vehicle
{
    public Guid TechnicalId { get; set; }
    public Guid? MakeTechnicalId { get; set; }
    public Guid? ModelTechnicalId { get; set; }
    public Guid? BodyTypeTechnicalId { get; set; }
    public Guid? VersionTechnicalId { get; set; }
    public string Generation { get; set; }
    public int? ModelYear { get; set; }
}
