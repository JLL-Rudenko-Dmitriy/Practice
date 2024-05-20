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

    public override DeflectorState GetDamage(int damageValue)
    {
        if (damageValue == 0)
        {
            if (_fotoneDamageCounter - 1 > 0)
            {
                _fotoneDamageCounter -= 1;
                return DeflectorState.Ok;
            }
            else
            {
                return DeflectorState.CrewDied;
            }
        }
        return Deflector.GetDamage(damageValue);
    }

    public override DeflectorState GetStatus()
    {
        return Deflector.GetStatus();
    }
}