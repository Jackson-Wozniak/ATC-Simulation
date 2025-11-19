namespace Backend.Domain.ValueObjects;

public class CoordinatesNauticalMiles
{
    public double X { get; set; }
    public double Y { get; set; }
    public double AltitudeFt { get; set; }

    public static CoordinatesNauticalMiles From(double x, double y, double alt)
    {
        return new CoordinatesNauticalMiles
        {
            X = x,
            Y = y,
            AltitudeFt = alt
        };
    }
}