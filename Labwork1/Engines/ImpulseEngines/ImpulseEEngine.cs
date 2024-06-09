using Labworks.Fuels;
namespace Labworks.Engines.ImpulseEngines;

public class ImpulseEEngine :  IImpulseEngine
{
    private const double IncreaseCoefficient = 5.0;
    private const double ImpulseEPowerConsumption = 120;
    private const double ImpulseEFuelConsumption = 12.0;

    public double FuelConsumption { get; init; } = ImpulseEFuelConsumption;
    public double Power { get; init; } = ImpulseEPowerConsumption;

    public double GetRequiredFuel(double distance)
    {
        return (FuelConsumption + FuelConsumption * IncreaseCoefficient) * (distance / ((double.Pow(2,Power)+Power)));
    }
    
    public double GetTime(double distance)
    {
        return distance / (double.Pow(2, Power) - Power);
    }
}
