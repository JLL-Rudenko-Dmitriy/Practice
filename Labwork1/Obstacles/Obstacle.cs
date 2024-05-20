using Labworks.DamageTypes;
using Labworks.Ships;

namespace Labworks.Obstacles;

public interface IObstacle
{
    public abstract void HitShip(Ship ship);
}