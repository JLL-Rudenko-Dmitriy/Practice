using Labworks.Fuels;
namespace Labworks.Engines.ImpulseEngines;

public class ImpulseEEngine : Engine
{
    public ImpulseEEngine() : base(new ConstEnginesPowers().PowerImpulseE)
    { }

    public override void StartEngine(Fuel fuel)
    {
        IncreaseCoeff = double.Log2(Power);
        return; 
    }

    public override double GetCurrentPower(Fuel fuel)
    {
        fuel.Value -= 150; 
        return base.Power;
    }

    public override double GetNewFuelValue(Fuel fuel)
    {
        throw new NotImplementedException();
    }

    public override void IncreastDelta()
    {
        IncreaseCoeff++;
        base.Power = double.Exp(IncreaseCoeff);
    }
}
