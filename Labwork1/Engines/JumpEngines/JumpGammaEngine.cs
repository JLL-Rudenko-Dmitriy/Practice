using Labworks.Fuels;
namespace Labworks.Engines.JumpEngines;

public class JumpGammaEngine : Engine, IJumpEngine
{
    private const double IncreaseCoefficient = 5.0;
    private const double JumpGammaPowerConsumption = 2024;
    private const double JumpGammaFuelConsumption = 32.0;
    public JumpGammaEngine()
    {
        Power = JumpGammaPowerConsumption;
        FuelConsumption = JumpGammaFuelConsumption;
    }

    public override double GetRequiredFuel(double distance)
    {
        return (FuelConsumption + FuelConsumption * double.Pow((distance/(Power*2)), 2)) * (distance/(Power*2));
    }
    
    public override double GetTime(double distance)
    {
        return distance / Power;
    }
}