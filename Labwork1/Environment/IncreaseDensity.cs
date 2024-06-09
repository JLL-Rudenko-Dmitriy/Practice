using Labworks.Engines.JumpEngines;
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
    
    public WalkThroughResult LaunchShip(Ship ship)
    {
        if (ship.JumpEngine is null)
        {
            return new WalkThroughResult.InvalidEngine();
        }
            
        if (!ship.JumpEngine.CanJumpOver(Distance))
        {
            return new WalkThroughResult.LowJumpDistance();
        }
        
        var fuelValue = ship.JumpEngine.GetRequiredFuel(Distance);

        foreach (var obstacle in ObstaclesList)
        {
            obstacle.HitShip(ship);
        }

        var time = ship.JumpEngine.GetTime(Distance);

        return ship.ShipState switch
        {
            ShipState.Ok => new WalkThroughResult.Success(0,fuelValue, time),
            ShipState.CrewDied => new WalkThroughResult.CrewDie(),
            _ => new WalkThroughResult.Destroyed()
        };
    }
}