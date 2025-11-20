using Backend.Domain.ValueObjects;
using Backend.Simulation.Physics.Utils;

namespace Backend.Tests.Simulation.Physics.Utils;

public class FlightPhysicsUtilsTest
{
    /*
    --------------------- NewPosition tests -----------------------
    */
    [Fact]
    public void NewPosition_MoveNortheast_UpdatesCorrectly()
    {
        CoordinatesNauticalMiles position = CoordinatesNauticalMiles.From(0,0,0);
        CoordinatesNauticalMiles updated = FlightPhysicsUtils.NewPosition(
            position, 45, 59.2484, 0, TimeSpan.FromSeconds(1));
        Assert.Equal(70.71, updated.X, 2);
        Assert.Equal(70.71, updated.Y, 2);
        Assert.Equal(0, updated.AltitudeFt);
    }

    [Fact]
    public void NewPosition_MoveSouthwest_UpdatesCorrectly()
    {
        CoordinatesNauticalMiles position = CoordinatesNauticalMiles.From(0,0,0);
        CoordinatesNauticalMiles updated = FlightPhysicsUtils.NewPosition(
            position, 225, 59.2484, 0, TimeSpan.FromSeconds(1));
        Assert.Equal(-70.71, updated.X, 2);
        Assert.Equal(-70.71, updated.Y, 2);
        Assert.Equal(0, updated.AltitudeFt);
    }
    
    [Fact]
    public void NewPosition_MoveEast_UpdatesCorrectly()
    {
        CoordinatesNauticalMiles position = CoordinatesNauticalMiles.From(0,0,0);
        CoordinatesNauticalMiles updated = FlightPhysicsUtils.NewPosition(
            position, 90, 59.2484, 0, TimeSpan.FromSeconds(1));
        Assert.Equal(100, updated.X, 2);
        Assert.Equal(0, updated.Y, 2);
        Assert.Equal(0, updated.AltitudeFt);
    }
    
    [Fact]
    public void NewPosition_MoveNorth_UpdatesCorrectly()
    {
        CoordinatesNauticalMiles position = CoordinatesNauticalMiles.From(0,0,0);
        CoordinatesNauticalMiles updated = FlightPhysicsUtils.NewPosition(
            position, 360, 59.2484, 0, TimeSpan.FromSeconds(1));
        Assert.Equal(0, updated.X, 2);
        Assert.Equal(100, updated.Y, 2);
        Assert.Equal(0, updated.AltitudeFt);
        
        position = CoordinatesNauticalMiles.From(0,0,0);
        updated = FlightPhysicsUtils.NewPosition(
            position, 0, 59.2484, 0, TimeSpan.FromSeconds(1));
        Assert.Equal(0, updated.X, 2);
        Assert.Equal(100, updated.Y, 2);
        Assert.Equal(0, updated.AltitudeFt);
    }
    
    /*
    --------------------- NewAltitude tests -----------------------
    */
    [Fact]
    public void NewAltitude_NoDuration_DoesNotUpdate()
    {
        double altitude = 0;
        Assert.Equal(altitude, FlightPhysicsUtils.NewAltitude(
            altitude, 100, 10, TimeSpan.Zero));
        Assert.Equal(altitude, FlightPhysicsUtils.NewAltitude(
            altitude, 100, -10, TimeSpan.Zero));
        
        altitude = 100;
        Assert.Equal(altitude, FlightPhysicsUtils.NewAltitude(
            altitude, 100, 20, TimeSpan.Zero));
        Assert.Equal(altitude, FlightPhysicsUtils.NewAltitude(
            altitude, 100, -20, TimeSpan.Zero));
        
        altitude = 10000;
        Assert.Equal(altitude, FlightPhysicsUtils.NewAltitude(
            altitude, 100, 30, TimeSpan.Zero));
        Assert.Equal(altitude, FlightPhysicsUtils.NewAltitude(
            altitude, 100, -30, TimeSpan.Zero));
    }
    
    [Fact]
    public void NewAltitude_PositivePitch_IncreasesAltitude()
    {
        const double initialAltitude = 1000;
        const double speedKnots = 60;
        const double pitchDegrees = 30;
        TimeSpan duration = TimeSpan.FromSeconds(60);

        double newAltitude = FlightPhysicsUtils.NewAltitude(initialAltitude, speedKnots, pitchDegrees, duration);
        
        Assert.True(newAltitude > initialAltitude);
        
        double expectedDelta = speedKnots.KnotsToFeetPerSec() * Math.Sin(pitchDegrees.ToRadians()) * duration.TotalSeconds;
        Assert.Equal(initialAltitude + expectedDelta, newAltitude, 5);
    }
    
    [Fact]
    public void NewAltitude_NegativePitch_DecreasesAltitude()
    {
        const double initialAltitude = 1000;
        const double speedKnots = 60;
        const double pitchDegrees = -10;
        TimeSpan duration = TimeSpan.FromSeconds(60);

        double newAltitude = FlightPhysicsUtils.NewAltitude(initialAltitude, speedKnots, pitchDegrees, duration);
        
        Assert.True(newAltitude < initialAltitude);
        
        double expectedDelta = speedKnots.KnotsToFeetPerSec() * Math.Sin(pitchDegrees.ToRadians()) * duration.TotalSeconds;
        Assert.Equal(initialAltitude + expectedDelta, newAltitude, 5);
    }
}