using Labworks.DamageTypes;
using Labworks.States;

namespace Labworks.HullStrengths;

public abstract class HullStrengthClass
{
    public int DamageCounter { get; set; }
    public HullStrengthState HullStregthStatus;

    protected void UpdateHullStrengthState()
    {
        if (DamageCounter <= 0)
        {
            HullStregthStatus = HullStrengthState.HullStrengthDestroyed;
        }
    }
    public abstract void GetDamage(int damageValue);
    public abstract HullStrengthState GetStatus();
}