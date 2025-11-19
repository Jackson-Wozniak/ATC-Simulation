using Backend.Domain.ValueObjects;

namespace Backend.Simulation.Physics.Utils;

public static class FlightTrajectoryUtils
{
    public static double HeadingTo(this CoordinatesNauticalMiles from, CoordinatesNauticalMiles to)
    {
        double differenceX = to.X - from.X;
        double differenceY = to.Y - from.Y;

        double radians = Math.Atan2(differenceY, differenceX);

        return radians.ToDegrees();
    }
}