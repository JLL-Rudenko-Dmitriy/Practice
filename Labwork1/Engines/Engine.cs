using Labworks.Engines.ImpulseEngines;
using Labworks.Engines.JumpEngines;
using Labworks.Fuels;
namespace Labworks.Engines;

public interface IEngine
{
    protected double FuelConsumption { get; init; }
    protected double Power { get; init; }
    
    public abstract double GetRequiredFuel(double distance);
    public abstract double GetTime(double distance);
}
