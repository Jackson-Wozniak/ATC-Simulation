namespace Backend.Simulation.Physics.Utils;

public static class PhysicsUtils
{
    public static double ToRadians(this double degrees)
    {
        return degrees * (Math.PI / 180);
    }

    public static double ToDegrees(this double rads)
    {
        return rads * (180 / Math.PI);
    }

    public static double KnotsToFeetPerSec(this double knots)
    {
        return knots * 1.68781;
    }
}