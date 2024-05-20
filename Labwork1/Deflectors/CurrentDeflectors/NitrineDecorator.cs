using Labworks.States;
using Labworks.DamageTypes;

namespace Labworks.Deflectors.CurrentDeflectors;

public class NitrineDecorator : Deflector
{
    private Deflector _deflector;
    private const int HugeDamage = 80;
    
    public NitrineDecorator(Deflector deflector)
    {
        _deflector = deflector;
    }

    public override DeflectorState GetDamage(int damageValue)
    {
        return damageValue == HugeDamage ? DeflectorState.Ok : _deflector.GetDamage(damageValue);
    }

    public override DeflectorState GetStatus()
    {
        return _deflector.GetStatus();
    }
}