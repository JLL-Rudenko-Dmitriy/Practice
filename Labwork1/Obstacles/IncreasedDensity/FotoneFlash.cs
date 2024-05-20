using Labworks.Deflectors;
using Labworks.Ships;
using Labworks.States;

namespace Labworks.Obstacles;

public class FotoneFlash: IIncreaseDensityObstacle
{
    private const int FotoneDamage = 0;
    public void HitShip(Ship ship)
    {
        if (ship.Deflector is not FotoneDecorator)
        {
            ship.ShipState = ShipState.CrewDied;
            return;
        }
        ship.Deflector.GetDamage(FotoneDamage);
    }
}