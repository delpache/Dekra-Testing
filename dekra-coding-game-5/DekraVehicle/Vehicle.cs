namespace DekraVehicle;

public class Vehicle
{
    private string _color;
    private string _location;
    private string _energy;
    public Vehicle(string color, string location, string energy)
    {
        _color = !string.IsNullOrEmpty(color) ? color : throw new Exception();
        _location = !string.IsNullOrEmpty(location) ? location : throw new Exception();
        _energy = !string.IsNullOrEmpty(energy) ? energy : throw new Exception();
    }
    public bool IsEligibleForSelling()
    {
        return (_color == "color1" && _location == "location1") || (_energy == "energy1" && _location == "location2");
    }
}
