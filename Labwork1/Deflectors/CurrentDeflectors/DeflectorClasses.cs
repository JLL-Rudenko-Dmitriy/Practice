using Labworks.DamageTypes;
using Labworks.States;

namespace Labworks.Deflectors.CurrentDeflectors;

public class DeflectorClassOne : Deflector
{
    public DeflectorClassOne()
    {
        DamageCounter = 4;
        DeflectorStatus = DeflectorState.Ok;
    }

    public override DeflectorState GetStatus()
    {
        return DeflectorStatus;
    }

    public override ShipState GetDamage(int damageValue)
    {
        var existDamage = new DamageType();
        if (damageValue == existDamage.SmallDamage)
        {
            DamageCounter -= 2;
        }
        else if (damageValue == existDamage.MediumDamage)
        {
            DamageCounter -= 4;
        }
        else
        {
            if (damageValue == existDamage.FotoneDamage)
            {
                DeflectorStatus = DeflectorState.CrewDied;
                return ShipState.CrewDied;
            }

            DeflectorStatus = DeflectorState.DeflectorDestroyed;
            return ShipState.ShipDestroyed;
        }

        UpdateDeflectorStatus();
        return ShipState.Ok;
    }
}

public class DeflectorClassTwo : Deflector
{
    public DeflectorClassTwo()
    {
        DamageCounter = 31;
        DeflectorStatus = DeflectorState.Ok;
    }

    public override DeflectorState GetStatus()
    {
        return DeflectorStatus;
    }

    public override ShipState GetDamage(int damageValue)
    {
        var existDamage = new DamageType();
        if (damageValue == existDamage.SmallDamage)
        {
            DamageCounter -= 3;
        }
        else if (damageValue == existDamage.MediumDamage)
        {
            DamageCounter -= 10;
        }
        else
        {
            if (damageValue == existDamage.FotoneDamage)
            {
                DeflectorStatus = DeflectorState.CrewDied;
                return ShipState.CrewDied;
            }

            DeflectorStatus = DeflectorState.DeflectorDestroyed;
            return ShipState.ShipDestroyed;
        }

        UpdateDeflectorStatus();
        return ShipState.Ok;
    }
}

public class DeflectorClassThree : Deflector
{
    public DeflectorClassThree()
    {
        DamageCounter = 80;
        DeflectorStatus = DeflectorState.Ok;
    }

    public override DeflectorState GetStatus()
    {
        return DeflectorStatus;
    }

    public override ShipState GetDamage(int damageValue)
    {
        var existDamage = new DamageType();
        if (damageValue == existDamage.SmallDamage)
        {
            DamageCounter -= 2;
        }
        else if (damageValue == existDamage.MediumDamage)
        {
            DamageCounter -= 8;
        }
        else if (damageValue == existDamage.HugeDamage)
        {
            DamageCounter -= 80;
        }
        else
        {
            if (damageValue == existDamage.FotoneDamage)
            {
                DeflectorStatus = DeflectorState.CrewDied;
                return ShipState.CrewDied;
            }

            DeflectorStatus = DeflectorState.DeflectorDestroyed;
            return ShipState.ShipDestroyed;
        }

        UpdateDeflectorStatus();
        return ShipState.Ok;
    }
}

