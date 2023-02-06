namespace DekraVehicle;

public class VehicleRange
{
    public Guid TechnicalId { get; set; }
    public Guid? MakeTechnicalId { get; set; }
    public Guid? ModelTechnicalId { get; set; }
    public Guid? BodyTypeTechnicalId { get; set; }
    public Guid? VersionTechnicalId { get; set; }
    public string Generation { get; set; }
    public int? ModelYear { get; set; }
    public string RangeName { get; set; }
}

public class VehicleRangeMatch
{
    public Guid TechnicalId { get; set; }
    public Guid? MakeTechnicalId { get; set; }
    public Guid? ModelTechnicalId { get; set; }
    public Guid? BodyTypeTechnicalId { get; set; }
    public Guid? VersionTechnicalId { get; set; }
    public string Generation { get; set; }
    public int? ModelYear { get; set; }
    public string RangeName { get; set; }
    public int? Score { get; set; }
}

