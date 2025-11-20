using System.Numerics;
using Backend.Domain.Entities;
using Backend.Simulation.Physics.Utils;

namespace Backend.Simulation.Physics.Services;

public class FlightPhysicsService(FlightTrajectoryService flightTrajectoryService)
{
    public void UpdateAircraftState(Aircraft aircraft, TimeSpan duration)
    {
        /*
        TODO: foreach duration in durationbeforetrajectoryupdate
            1.) Get current trajectory/aircraftstate
            2.) update position, altitude etc. based on trajectory
            3.) update trajectory based on targets in AircraftState
            
        Current approach will be to just update trajectory after
        */
        AircraftState state = aircraft.State;
        aircraft.State.Coordinates = FlightPhysicsUtils.NewPosition(
            state.Coordinates, state.Heading, 
            state.SpeedKnots, state.Pitch, duration);
        
        flightTrajectoryService.UpdateAircraftTrajectory(aircraft, duration);
    }
}