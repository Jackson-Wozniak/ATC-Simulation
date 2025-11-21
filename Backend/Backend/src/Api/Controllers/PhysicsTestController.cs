using Backend.Domain.Entities;
using Backend.Domain.ValueObjects;
using Backend.Simulation.Physics.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[ApiController]
[Route("api/test")]
public class PhysicsTestController(
    FlightPhysicsService flightPhysicsService) : ControllerBase
{
    [HttpGet]
    public List<string> Test()
    {
        Aircraft aircraft = new Aircraft
        {
            State = new AircraftState
            {
                Coordinates = CoordinatesNauticalMiles.From(0, 0, 0),
                TargetCoordinates = CoordinatesNauticalMiles.From(0, 0, 0),
                SpeedKnots = 100,
                TargetSpeedKnots = 100,
                Heading = 45,
                TargetHeading = 45,
                Pitch = 10
            }
        };

        List<string> coordinates = new List<string>();

        for (var i = 0; i < 10; i++)
        {
            string pos = $"{i}: {aircraft.State.Coordinates.X},{aircraft.State.Coordinates.Y}";
            coordinates.Add(pos);
            flightPhysicsService.UpdateAircraftState(aircraft, TimeSpan.FromSeconds(1));
        }

        return coordinates;
    }
}