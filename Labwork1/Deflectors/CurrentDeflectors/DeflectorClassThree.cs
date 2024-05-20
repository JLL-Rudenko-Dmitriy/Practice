using Labworks.DamageTypes;
using Labworks.States;

namespace Labworks.Deflectors.CurrentDeflectors;

public class DeflectorClassThree : Deflector
{
    public DeflectorClassThree()
    {
        DeflectorPoints = 80;
        DeflectorStatus = DeflectorState.Ok;
    }

    public override DeflectorState GetStatus()
    {
        return DeflectorStatus;
    }

    public override DeflectorState GetDamage(int damageValue)
    {
        UpdateDeflectorStatus(damageValue);
        return DeflectorState.Ok;
    }
}

