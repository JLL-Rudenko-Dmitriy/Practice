using Labworks.Fuels;
namespace Labworks.Engines.ImpulseEngines;

public class ImpulseCEngine : Engine, IImpulseEngine
{
    private const double ImpulseCPowerConsumption = 12.0;
    private const double ImpulseCFuelConsumption = 120.0;
    
    public ImpulseCEngine()
    {
        Power = ImpulseCPowerConsumption;
        FuelConsumption = ImpulseCFuelConsumption;
    }

    public override double GetRequiredFuel(double distance)
    {
        return (distance/Power) * FuelConsumption;
    }
    
    public override double GetTime(double distance)
    {
        return distance / Power;
    }
}