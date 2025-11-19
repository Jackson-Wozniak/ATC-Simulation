using Backend.Simulation.Physics.Utils;

namespace Backend.Tests.Simulation.Physics.Utils;

public class FlightPhysicsUtilsTest
{
    /*
    --------------------- NewPosition tests -----------------------
    */
    
    
    
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