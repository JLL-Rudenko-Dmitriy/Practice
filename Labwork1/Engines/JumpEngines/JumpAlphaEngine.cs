using Labworks.Fuels;
namespace Labworks.Engines.JumpEngines;

public class JumpAlphaEngine : Engine, IJumpEngine
{
    private const double IncreaseCoefficient = 5.0;
    private const double JumpAlphaPowerConsumption = 512;
    private const double JumpAlphaFuelConsumption = 8.0;
    public JumpAlphaEngine()
    {
        Power = JumpAlphaPowerConsumption;
        FuelConsumption = JumpAlphaFuelConsumption;
    }

    public override double GetRequiredFuel(double distance)
    {
        return (FuelConsumption + FuelConsumption * IncreaseCoefficient) * (distance/(Power*2));
    }

    public override double GetTime(double distance)
    {
        return distance / Power;
    }
}