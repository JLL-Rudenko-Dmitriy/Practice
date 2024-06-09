using Labworks.Fuels;
namespace Labworks.Engines.JumpEngines;

public class JumpOmegaEngine : IJumpEngine
{
    private const double JumpOmegaDistance = 512; 
    private const double IncreaseCoefficient = 5.0;
    private const double JumpOmegaPowerConsumption = 1024;
    private const double JumpOmegaFuelConsumption = 16.0;

    public double FuelConsumption { get; init; } = JumpOmegaFuelConsumption;
    public double Power { get; init; } = JumpOmegaPowerConsumption;

    public double GetRequiredFuel(double distance)
    {
        return (FuelConsumption + FuelConsumption * double.Log(distance/(Power*2), 5)) * (distance/(Power*2));
    }
    
    public double GetTime(double distance)
    {
        return distance / Power;
    }
    
    public bool CanJumpOver(double distance)
    {
        return JumpOmegaDistance > distance ? true : false;
    }
}