using Labworks.Fuels;
namespace Labworks.Engines.JumpEngines;

public class JumpAlphaEngine : IJumpEngine
{
    private const double JumpAlphaDistance = 128;
    private const double IncreaseCoefficient = 5.0;
    private const double JumpAlphaPowerConsumption = 512;
    private const double JumpAlphaFuelConsumption = 8.0;

    public double FuelConsumption { get; init; } = JumpAlphaFuelConsumption;
    public double Power { get; init; } = JumpAlphaPowerConsumption;

    public  double GetRequiredFuel(double distance)
    {
        return (FuelConsumption + FuelConsumption * IncreaseCoefficient) * (distance/(Power*2));
    }

    public  double GetTime(double distance)
    {
        return distance / Power;
    }

    public bool CanJumpOver(double distance)
    {
        return JumpAlphaDistance > distance ? true : false;
    }
}