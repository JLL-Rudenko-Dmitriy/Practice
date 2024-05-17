using Labworks.States;
using Labworks.DamageTypes;

namespace Labworks.Deflectors.CurrentDeflectors;

public class NitrineDecorator : Deflector
{
    private Deflector _deflector;
    
    public NitrineDecorator(Deflector deflector)
    {
        _deflector = deflector;
    }

    public override ShipState GetDamage(int damageValue)
    {
        
        ShipState shipState = ShipState.Ok;
        
        if (damageValue == new DamageType().HugeDamage)
        {
            return ShipState.Ok;
        }
        else
        {
            shipState = _deflector.GetDamage(damageValue);
        }
        
        return shipState;
    }

    public override DeflectorState GetStatus()
    {
        return _deflector.GetStatus();
    }
}