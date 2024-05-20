using Labworks.Ships;
using Labworks.States;

namespace Labworks.Obstacles;

public class SmallMeteor: ISpaceObstacle
{
    private const int SmallDamage = 2;
    public void HitShip(Ship ship)
    {
        if ((ship.Deflector is not null) && (ship.Deflector.GetStatus() == DeflectorState.Ok))
        {
            ship.Deflector.GetDamage(SmallDamage);
            return;
        }
        ship.HullStrengthClass.GetDamage(SmallDamage);
    }
}
