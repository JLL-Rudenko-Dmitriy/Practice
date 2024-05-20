using Labworks.Obstacles;
using Labworks.Ships;
using Labworks.States;

namespace Labworks.SpaceEnvironments;

public class IncreaseDensity: IEnvironment
{
    private List<IIncreaseDensityObstacle> ObstaclesList { get; init; }
    private readonly double _distance;
    
    public double Distance
    {
        get => _distance;
        init => _distance = value>0.0 ? value : 0.0;
    }

    public IncreaseDensity(double distance, List<IIncreaseDensityObstacle> obstaclesList)
    {
        _distance = distance;
        ObstaclesList = obstaclesList;
    }
    
    public WalkthroughRecord LaunchShip(Ship ship)
    {
        var status = new
        {
            Success = "Covered",
            InvalidEngine = "InvalidEngine",
            Destroyed = "ShipDestroyed",
            CrewDied = "CrewDied"
        };
        
        if (ship.JumpEngine is null)
        {
            return new WalkthroughRecord(status.InvalidEngine, 0,0,0);
        }
        
        var fuelValue = ship.JumpEngine.GetRequiredFuel(Distance);

        foreach (var obstacle in ObstaclesList)
        {
            obstacle.HitShip(ship);
        }

        var time = ship.JumpEngine.GetTime(Distance);

        return ship.ShipState switch
        {
            ShipState.Ok => new WalkthroughRecord(status.Success, 0,fuelValue, time),
            ShipState.CrewDied => new WalkthroughRecord(status.CrewDied, 0, 0,0),
            _ => new WalkthroughRecord(status.Destroyed, 0, 0,0)
        };
    }
}