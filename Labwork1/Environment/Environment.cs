using Labworks.Engines;
using Labworks.Engines.JumpEngines;
using Labworks.Obstacles;
using Labworks.Ships;

namespace Labworks.SpaceEnvironments;


public interface IEnvironment
{
    public double Distance { get; init; }
    public WalkThroughResult LaunchShip(Ship ship);
}

