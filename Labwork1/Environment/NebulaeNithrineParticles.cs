using Labworks.Obstacles.NithrinParticles;
using Labworks.Ships;
using Labworks.States;

namespace Labworks.SpaceEnvironments;

public class NebulaeNithrineParticles: IEnvironment
{
    private List<INithrineObstacle> ObstaclesList { get; init; }
    private readonly double _distance;
    
    public double Distance
    {
        get => _distance;
        init => _distance = value>0.0 ? value : 0.0;
    }

    public NebulaeNithrineParticles(double distance, List<INithrineObstacle> obstaclesList)
    {
        _distance = distance;
        ObstaclesList = obstaclesList;
    }

    public WalkThroughResult LaunchShip(Ship ship)
    {
        if (ship.ImpulseEngine is null)
        {
            return new WalkThroughResult.InvalidEngine();
        }
        var fuelValue = ship.ImpulseEngine.GetRequiredFuel(Distance);

        foreach (var obstacle in ObstaclesList)
        {
            obstacle.HitShip(ship);
        }

        var time = ship.ImpulseEngine.GetTime(Distance);
        
        return ship.ShipState == ShipState.ShipDestroyed ? 
            new WalkThroughResult.Destroyed() : 
            new WalkThroughResult.Success(fuelValue,0, time);
    }
}