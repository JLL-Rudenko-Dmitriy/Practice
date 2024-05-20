using Labworks.Obstacles;
using Labworks.Ships;
using Labworks.States;

namespace Labworks.SpaceEnvironments;

public class SimpleSpace: IEnvironment
{
    private List<ISpaceObstacle> ObstaclesList { get; init; }
    private readonly double _distance;

    public double Distance
    {
        get => _distance;
        init => _distance = value>0.0 ? value : 0.0;
    }
    
    public SimpleSpace( double distance, IEnumerable<ISpaceObstacle> obstaclesList)
    {
        Distance = distance;
        ObstaclesList = obstaclesList.ToList();
    }

    public WalkthroughRecord LaunchShip(Ship ship)
    {
        var status = new
        {
            Success = "Covered",
            InvalidEngine = "InvalidEngine",
            Destroyed = "ShipDestroyed"
        };
        
            
        if (ship.ImpulseEngine is null)
        {
            return new WalkthroughRecord(status.InvalidEngine, 0,0,0);
        }
        var fuelValue = ship.ImpulseEngine.GetRequiredFuel(Distance);

        foreach (var obstacle in ObstaclesList)
        {
            obstacle.HitShip(ship);
        }

        var time = ship.ImpulseEngine.GetTime(Distance);
        
        return ship.ShipState == ShipState.ShipDestroyed ? 
            new WalkthroughRecord(status.Destroyed, 0,0, 0) : 
            new WalkthroughRecord(status.Success, fuelValue,0,time);
    }
}