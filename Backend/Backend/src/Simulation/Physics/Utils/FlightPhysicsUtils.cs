using Backend.Domain.ValueObjects;

namespace Backend.Simulation.Physics.Utils;

public class FlightPhysicsUtils
{
    public static CoordinatesNauticalMiles NewPosition(
        CoordinatesNauticalMiles currentPosition, double heading,
        double speedKnots, double pitch, TimeSpan duration)
    {
        double angle = heading.ToRadians();
        double ftTraveled = speedKnots.KnotsToFeetPerSec() * duration.TotalSeconds;

        double changeX = ftTraveled * Math.Sin(angle);
        double changeY = ftTraveled * Math.Cos(angle);
        
        return CoordinatesNauticalMiles.From(
            currentPosition.X + changeX, 
            currentPosition.Y + changeY, 
            NewAltitude(currentPosition.AltitudeFt, speedKnots, pitch, duration)
        );
    }

    public static double NewAltitude(double altitudeFt, double speedKnots, double pitch, TimeSpan duration)
    {
        return altitudeFt + (speedKnots.KnotsToFeetPerSec()
                             * Math.Sin(pitch.ToRadians()) * duration.TotalSeconds);
    }
}