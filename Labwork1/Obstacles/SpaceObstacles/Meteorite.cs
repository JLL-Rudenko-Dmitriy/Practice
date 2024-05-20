using Labworks.Ships;
using Labworks.States;

namespace Labworks.Obstacles;


public class Meteorite : ISpaceObstacle
{
    
    private const int MediumDamage = 8;
    public void HitShip(Ship ship)
    {
        if ((ship.Deflector is not null) && (ship.Deflector.GetStatus() == DeflectorState.Ok))
        {
            ship.Deflector.GetDamage(MediumDamage);
            return;
        }
        ship.HullStrengthClass.GetDamage(MediumDamage);
    }    
}