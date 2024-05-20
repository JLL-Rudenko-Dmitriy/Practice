using Labworks.Fuels;
namespace Labworks.Engines;

public abstract class Engine
{
    protected double FuelConsumption { get; init; }
    protected double Power { get; init; }
    
    public abstract double GetRequiredFuel(double distance);
    public abstract double GetTime(double distance);
}
