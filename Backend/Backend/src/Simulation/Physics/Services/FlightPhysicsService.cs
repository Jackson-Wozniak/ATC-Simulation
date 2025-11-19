using System.Numerics;
using Backend.Domain.Entities;

namespace Backend.Simulation.Physics.Services;

public class FlightPhysicsService
{
    public void UpdateAircraftState(Aircraft aircraft, TimeSpan duration)
    {
        /*
        TODO: foreach duration in durationbeforetrajectoryupdate
            1.) Get current trajectory/aircraftstate
            2.) update position, altitude etc. based on trajectory
            3.) update trajectory based on targets in AircraftState
        */
    }
}