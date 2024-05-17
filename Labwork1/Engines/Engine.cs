using Labworks.Fuels;
namespace Labworks.Engines;

public abstract class Engine
{
    public double Power { get; set; }
    public double IncreaseCoeff { get; set; }


    public Engine(double enginePower)
    {
        Power = enginePower;
    }

    public abstract void StartEngine(Fuel fuel);

    public abstract double GetCurrentPower(Fuel fuel);

    public abstract double GetNewFuelValue(Fuel fuel);

    public abstract void IncreastDelta();
}
