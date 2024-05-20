using Labworks.Fuels;
namespace Labworks.Engines.JumpEngines;

public class JumpOmegaEngine : Engine, IJumpEngine
{
    private const double IncreaseCoefficient = 5.0;
    private const double JumpOmegaPowerConsumption = 1024;
    private const double JumpOmegaFuelConsumption = 16.0;
    public JumpOmegaEngine()
    {
        Power = JumpOmegaPowerConsumption;
        FuelConsumption = JumpOmegaFuelConsumption;
    }

    public override double GetRequiredFuel(double distance)
    {
        return (FuelConsumption + FuelConsumption * double.Log(distance/(Power*2), 5)) * (distance/(Power*2));
    }
    
    public override double GetTime(double distance)
    {
        return distance / Power;
    }
}