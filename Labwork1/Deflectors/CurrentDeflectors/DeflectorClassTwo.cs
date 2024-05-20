using Labworks.DamageTypes;
using Labworks.States;


namespace Labworks.Deflectors.CurrentDeflectors;

public class DeflectorClassTwo : Deflector
{
    public DeflectorClassTwo()
    {
        DeflectorPoints = 31;
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