using Labworks.Fuels;
namespace Labworks.Engines.ImpulseEngines;

public class ImpulseCEngine : IImpulseEngine
{
    private const double ImpulseCPowerConsumption = 12.0;
    private const double ImpulseCFuelConsumption = 120.0;

    public double FuelConsumption { get; init; } = ImpulseCFuelConsumption;
    public double Power { get; init; } = ImpulseCPowerConsumption;

    public double GetRequiredFuel(double distance)
    {
        return (distance/Power) * FuelConsumption;
    }
    
    public double GetTime(double distance)
    {
        return distance / Power;
    }
}