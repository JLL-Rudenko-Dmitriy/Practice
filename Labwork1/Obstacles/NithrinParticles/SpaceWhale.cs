using Labworks.Deflectors.CurrentDeflectors;
using Labworks.Ships;
using Labworks.States;

namespace Labworks.Obstacles.NithrinParticles;

public class SpaceWhale : INithrineObstacle
{
    private const int HugeDamage = 80;
    public void HitShip(Ship ship)
    {
        if ((ship.Deflector is not NitrineDecorator) || (ship.Deflector is not DeflectorClassThree))
        {
            ship.ShipState = ShipState.ShipDestroyed;
            return;
        }
        ship.Deflector.GetDamage(HugeDamage);
    }
}