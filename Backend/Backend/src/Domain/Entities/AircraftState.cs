using Backend.Domain.ValueObjects;

namespace Backend.Domain.Entities;

public class AircraftState
{
    public CoordinatesNauticalMiles Coordinates { get; set; }
    public CoordinatesNauticalMiles TargetCoordinates { get; set; }
    public double SpeedKnots { get; set; }
    public double TargetSpeedKnots { get; set; }
    public double Heading { get; set; }
    public double TargetHeading { get; set; }
    public double Pitch { get; set; }
    
    //TODO: will likely need an intermediary target for speed, position etc.
    //to handle 'current instructions' vs 'eventual destination'
}