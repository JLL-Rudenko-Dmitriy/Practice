using Labworks.DamageTypes;
using Labworks.States;
namespace Labworks.Deflectors;

public abstract class Deflector
{
    protected int DamageCounter;
    protected DeflectorState DeflectorStatus = DeflectorState.Ok;

    protected void UpdateDeflectorStatus()
    {
        if (DamageCounter <= 0)
        {
            DeflectorStatus = DeflectorState.DeflectorDestroyed;
        } 
    }
    public abstract ShipState GetDamage(int damageValue);
    public abstract DeflectorState GetStatus();
     
}