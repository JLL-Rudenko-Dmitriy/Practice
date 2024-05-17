using Labworks.DamageTypes;
using Labworks.Deflectors;
using Labworks.Engines;
using Labworks.Engines.ImpulseEngines;
using Labworks.HullStrengths;
using Labworks.States;
using Labworks.Fuels;
using Labworks.Obstacles;
using Labworks.SpaceEnvironments;

namespace Labworks.Ships;

public class Ship
{
    public Deflector? Deflector { get; set;  }
    public HullStrengthClass HullStrengthClass { get; set; }
    public ShipState ShipState { get; set; } = ShipState.Ok;

    public Engine FirstEngine { get; set; }
    public Engine SecondEngine { get; set; }

    public ActivePlasmaFuel PlasmaFuel { get; set; }
    public GravityMatterFuel GravityFuel { get; set; }
    
    public Ship(Deflector? deflector, HullStrengthClass hullStrengthClass, Engine firstEngine, Engine secondEngine, ActivePlasmaFuel plasmaFuel, GravityMatterFuel gravityFuel)
    {
        Deflector = deflector;
        HullStrengthClass = hullStrengthClass;
        ShipState = ShipState.Ok;
        FirstEngine = firstEngine;
        SecondEngine = secondEngine;
        PlasmaFuel = plasmaFuel;
        GravityFuel = gravityFuel;
    }

    public void GetDamage(int damageValue)
    {   
        
        if (Deflector is not null)
        {
            //Deflector work
            if (Deflector.GetStatus() != DeflectorState.DeflectorDestroyed)
            {
                ShipState = Deflector.GetDamage(damageValue);
            }
            
            //HullStrength work
            else
            {
                HullStrengthClass.GetDamage(damageValue);
                if (HullStrengthClass.GetStatus() == HullStrengthState.HullStrengthDestroyed)
                {
                    ShipState = ShipState.ShipDestroyed;
                    return;
                }
            }
        }
        else
        {   
            if (damageValue == new DamageType().FotoneDamage)
            {
                ShipState = ShipState.CrewDied;
                return;
            }
            
            HullStrengthClass.GetDamage(damageValue);
            if (HullStrengthClass.GetStatus() == HullStrengthState.HullStrengthDestroyed)
            {
                ShipState = ShipState.ShipDestroyed;
                return;
            }
        }
    }
    
    public ShipState TryToReach(ISpaceEnvironment environment)
    {
        int distance = environment.Distance;
        double resistCoeff = 1.0;

        Engine effectiveEngine = null;
        
        if (FirstEngine is null)
        {
            effectiveEngine = SecondEngine;
            resistCoeff = environment.GetResistCoefficient(SecondEngine);
        }

        if (SecondEngine is null)
        {
            effectiveEngine = FirstEngine;
            resistCoeff = environment.GetResistCoefficient(FirstEngine);
        }

        if ((FirstEngine is not null) && (SecondEngine is not null))
        {
            if (environment.GetResistCoefficient(FirstEngine) < environment.GetResistCoefficient(SecondEngine))
            {
                effectiveEngine = SecondEngine;
                resistCoeff = environment.GetResistCoefficient(SecondEngine);
            }
            else
            {
                effectiveEngine = FirstEngine;
                resistCoeff = environment.GetResistCoefficient(FirstEngine);
            }
        }
        
        Fuel currentFuel;
        if ((effectiveEngine is ImpulseCEngine) || (effectiveEngine is ImpulseEEngine))
        {
            currentFuel = GravityFuel;
        }
        else
        {
            currentFuel = PlasmaFuel;
        }
        
        while (distance > 0)
        {
            if (currentFuel.Value <= 0)
            {
                ShipState = ShipState.FuelEmpty;
                break;
            }
            distance -= (int)(effectiveEngine.GetCurrentPower(currentFuel) * resistCoeff);
            effectiveEngine.IncreastDelta();
        }
        
        if (currentFuel.Value < 0)
        {
            ShipState = ShipState.FuelEmpty;
            return ShipState;
        }
        
        foreach (Obstacle obstacle in environment.ObstaclesList)
        {
            GetDamage(obstacle.GiveDamage());
            if (ShipState != ShipState.Ok)
            {
                return ShipState;
            }
        }
        return ShipState;
    }
}