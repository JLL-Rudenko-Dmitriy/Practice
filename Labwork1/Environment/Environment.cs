using Labworks.Engines;
using Labworks.Engines.JumpEngines;
using Labworks.Obstacles;

namespace Labworks.SpaceEnvironments;



public interface ISpaceEnvironment
{
    public IEnumerable<Obstacle> ObstaclesList { get; set; }
    public int Distance { get; set; }
    public double GetResistCoefficient(Engine engine);
}

public class SimpleSpace : ISpaceEnvironment
{
    public IEnumerable<Obstacle> ObstaclesList { get; set; }
    public int Distance { get; set; }
    public SimpleSpace(IEnumerable<Obstacle> obstaclesCollection, int envDistance)
    {
        ObstaclesList = obstaclesCollection;
        Distance = envDistance;
    }

    public double GetResistCoefficient(Engine engine)
    {
        return 1;
    }
}

public class NebulaOfIncreasedDensity : ISpaceEnvironment
{
    public IEnumerable<Obstacle> ObstaclesList { get; set; }
    public int Distance { get; set; }

    public NebulaOfIncreasedDensity(IEnumerable<Obstacle> obstaclesCollection, int envDistance)
    {
        ObstaclesList = obstaclesCollection;
        Distance = envDistance;
    }

    public double GetResistCoefficient(Engine engine)
    {
        if ((engine.GetType() == typeof(JumpAlphaEngine)) ||
            (engine.GetType() == typeof(JumpOmegaEngine)) ||
            (engine.GetType() == typeof(JumpGammaEngine)))
        {
            return 1.0;
        }
        else
        {
            return 0.35;
        }
    }
}

public class NitrineParticleNebulae : ISpaceEnvironment
{
    public IEnumerable<Obstacle> ObstaclesList { get; set; }
    public int Distance { get; set; }

    public NitrineParticleNebulae(IEnumerable<Obstacle> obstaclesCollection, int envDistance)
    {
        ObstaclesList = obstaclesCollection;
        Distance = envDistance;
    }

    public double GetResistCoefficient(Engine engine)
    {
        if ((engine.GetType() == typeof(JumpAlphaEngine)) || 
            (engine.GetType() == typeof(JumpOmegaEngine)) || 
            (engine.GetType() == typeof(JumpGammaEngine)))
        {
            return 1.0;
        }
        else
        {
            return 0.34;
        }
    }
}

