using Labworks.DamageTypes;
using Labworks.States;

namespace Labworks.HullStrengths.CurrentHullStregthClasses;

public class HullStrengthClassOne : HullStrengthClass 
{
    public HullStrengthClassOne()
    {
        DamageCounter = 3;
        HullStregthStatus = HullStrengthState.Ok;
    }
    
    public override void GetDamage(int damageValue)
    {
        var existDamage = new DamageType();
        if (damageValue == existDamage.SmallDamage)
        {
            DamageCounter -= 2;
        }
        else
        {
            HullStregthStatus = HullStrengthState.HullStrengthDestroyed;
        }
        UpdateHullStrengthState();
    }

    public override HullStrengthState GetStatus()
    {
        return HullStregthStatus;
    }
}

public class HullStrengthClassTwo : HullStrengthClass 
{
    public HullStrengthClassTwo()
    {
        DamageCounter = 11;
        HullStregthStatus = HullStrengthState.Ok;
    }
    
    public override void GetDamage(int damageValue)
    {
        var existDamage = new DamageType();
        if (damageValue == existDamage.SmallDamage)
        {
            DamageCounter -= 2;
        }
        else if (damageValue == existDamage.MediumDamage)
        {
            DamageCounter -= 5;
        }
        else
        {
            HullStregthStatus = HullStrengthState.HullStrengthDestroyed;
        }
        UpdateHullStrengthState();
    }

    public override HullStrengthState GetStatus()
    {
        return HullStregthStatus;
    }
}

public class HullStrengthClassThree : HullStrengthClass 
{
    public HullStrengthClassThree()
    {
        DamageCounter = 101;
        HullStregthStatus = HullStrengthState.Ok;
    }
    
    public override void GetDamage(int damageValue)
    {
        var existDamage = new DamageType();
        if (damageValue == existDamage.SmallDamage)
        {
            DamageCounter -= 5;
        }
        else if (damageValue == existDamage.MediumDamage)
        {
            DamageCounter -= 20;
        }
        else
        {
            HullStregthStatus = HullStrengthState.HullStrengthDestroyed;
        }
        UpdateHullStrengthState();
    }


    public override HullStrengthState GetStatus()
    {
        return HullStregthStatus;
    }
}