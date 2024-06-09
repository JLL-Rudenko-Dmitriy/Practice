using Labworks.Fuels;
namespace Labworks.Engines.JumpEngines;

public class JumpGammaEngine :  IJumpEngine
{
    private const double JumpGammaDistance = 1024;
    private const double IncreaseCoefficient = 5.0;
    private const double JumpGammaPowerConsumption = 2024;
    private const double JumpGammaFuelConsumption = 32.0;

    public double FuelConsumption { get; init; } = JumpGammaFuelConsumption;
    public double Power { get; init; } = JumpGammaPowerConsumption;

    public double GetRequiredFuel(double distance)
    {
        return (FuelConsumption + FuelConsumption * double.Pow((distance/(Power*2)), 2)) * (distance/(Power*2));
    }
    
    public double GetTime(double distance)
    {
        return distance / Power;
    }
    
    public bool CanJumpOver(double distance)
    {
        return JumpGammaDistance > distance ? true : false;
    }
}