using Labworks.DamageTypes;
using Labworks.States;

namespace Labworks.Deflectors;

public class FotoneDecorator : Deflector
{
    private Deflector Deflector;
    private int _fotoneDamageCounter;

    public FotoneDecorator(Deflector deflector)
    {
        Deflector = deflector;
        _fotoneDamageCounter = 3;
    }

    public override ShipState GetDamage(int damageValue)
    {
        ShipState shipState = ShipState.Ok;
        if (damageValue == new DamageType().FotoneDamage)
        {
            if (_fotoneDamageCounter <= 0)
            {
                DeflectorStatus = DeflectorState.CrewDied;
                shipState = ShipState.CrewDied;
            }
            _fotoneDamageCounter -= 1;
        }
        else
        {
            shipState = Deflector.GetDamage(damageValue);
            DeflectorStatus = Deflector.GetStatus();
        }
        return shipState;
    }

    public override DeflectorState GetStatus()
    {
        return DeflectorStatus;
    }
}