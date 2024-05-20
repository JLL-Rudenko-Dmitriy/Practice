using Labworks.DamageTypes;
using Labworks.States;
namespace Labworks.Deflectors;

public abstract class Deflector
{
    protected int DeflectorPoints;
    protected DeflectorState DeflectorStatus = DeflectorState.Ok;

    protected DeflectorState UpdateDeflectorStatus(double damage)
    {
        return DeflectorPoints - damage <= 0? DeflectorState.DeflectorDestroyed : DeflectorState.Ok;
    }
    public abstract DeflectorState GetDamage(int damageValue);
    public abstract DeflectorState GetStatus();
     
}