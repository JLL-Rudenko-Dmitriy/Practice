using Labworks.Fuels;
namespace Labworks.Engines.ImpulseEngines;

public class ImpulseEEngine : Engine, IImpulseEngine
{
    private const double IncreaseCoefficient = 5.0;
    private const double ImpulseEPowerConsumption = 120;
    private const double ImpulseEFuelConsumption = 12.0;
    
    public ImpulseEEngine()
    {
        Power = ImpulseEPowerConsumption;
        FuelConsumption = ImpulseEFuelConsumption;
    }

    public override double GetRequiredFuel(double distance)
    {
        return (FuelConsumption + FuelConsumption * IncreaseCoefficient) * (distance / ((double.Pow(2,Power)+Power)));
    }
    
    public override double GetTime(double distance)
    {
        return distance / (double.Pow(2, Power) - Power);
    }
}
