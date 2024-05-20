using Labworks.DamageTypes;
using Labworks.States;

namespace Labworks.Deflectors.CurrentDeflectors;

public class DeflectorClassOne : Deflector
{
    public DeflectorClassOne()
    {
        DeflectorPoints = 4;
        DeflectorStatus = DeflectorState.Ok;
    }

    public override DeflectorState GetStatus()
    {
        return DeflectorStatus;
    }

    public override DeflectorState GetDamage(int damageValue)
    { 
        var state = UpdateDeflectorStatus(damageValue);
        if (state != DeflectorState.Ok)
        {
            return state;
        }

        DeflectorPoints -= damageValue;
        return state;
    }
}