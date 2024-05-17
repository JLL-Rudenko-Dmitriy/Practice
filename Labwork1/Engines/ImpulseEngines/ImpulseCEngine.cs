using Labworks.Fuels;
namespace Labworks.Engines.ImpulseEngines;

public class ImpulseCEngine : Engine
{
    public ImpulseCEngine() : base(new ConstEnginesPowers().PowerImpulseC)
    {
        
    }

    public override void StartEngine(Fuel fuel)
    {
        return; 
    }

    public override double GetCurrentPower(Fuel fuel)
    {
        fuel.Value -= 20;
        return base.Power;
    }

    public override double GetNewFuelValue(Fuel fuel)
    {
        throw new NotImplementedException();
    }

    public override void IncreastDelta()
    {
        return ;
    }
}