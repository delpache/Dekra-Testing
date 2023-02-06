using Xunit.Sdk;

namespace DekraVehicle.Tests;

public class VehicleTest
{
    private Vehicle vehicle;

    [Fact]
    public void Should_Be_Exception_When_Color_Not_Exist()
    {
        try
        {
            vehicle = this.GetVehicleInstance(string.Empty, "Location1", "Energy1");
        }
        catch (Exception ex)
        {
            Assert.Equal("Exception of type 'System.Exception' was thrown.", ex.Message);
        }

    }

    [Fact]
    public void Should_Be_Exception_When_Localisation_Not_Exist()
    {
        try
        {
            vehicle = this.GetVehicleInstance("Color1", string.Empty, "Energy1");
        }
        catch (Exception ex)
        {
            Assert.Equal("Exception of type 'System.Exception' was thrown.", ex.Message);
        }
    }

    [Fact]
    public void Should_Be_Exception_When_Energy_Not_Exist()
    {
        try
        {
            vehicle = this.GetVehicleInstance("Color1", "Location1", string.Empty);
        }
        catch (Exception ex)
        {
            Assert.Equal("Exception of type 'System.Exception' was thrown.", ex.Message);
        }
    }

    [Fact]
    public void Should_Be_True_When_Color1_And_Location1_In_IsEligibleForSelling()
    {
        vehicle = this.GetVehicleInstance("color1", "location1", "Energy1");
        Assert.True(vehicle.IsEligibleForSelling());
    }

    [Fact]
    public void Should_Be_True_When_Energy1_And_Location2_In_IsEligibleForSelling()
    {
        vehicle = this.GetVehicleInstance("color2", "location2", "energy1");
        Assert.True(vehicle.IsEligibleForSelling());
    }

    [Fact]
    public void Should_Be_False_When_Color2_In_IsEligibleForSelling()
    {
        vehicle = this.GetVehicleInstance("color2", "location2", "energy2");
        Assert.False(vehicle.IsEligibleForSelling());
    }

    public void Should_Be_False_When_Energy2_In_IsEligibleForSelling()
    {
        vehicle = this.GetVehicleInstance("color1", "location1", "energy2");
        Assert.False(vehicle.IsEligibleForSelling());
    }

    private Vehicle GetVehicleInstance(string color, string location, string energy)
    {
        return new Vehicle(color, location, energy);
    }

}