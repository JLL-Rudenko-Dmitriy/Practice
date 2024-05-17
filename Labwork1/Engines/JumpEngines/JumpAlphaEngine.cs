using Labworks.Fuels;
namespace Labworks.Engines.JumpEngines;

public class JumpAlphaEngine : Engine
{
    public JumpAlphaEngine() : base(new ConstEnginesPowers().PowerJumpAlpha)
    {
        IncreaseCoeff = 3;
    }

    public override void StartEngine(Fuel fuel)
    {
        IncreaseCoeff = 1;
    }
    
    public override double GetCurrentPower(Fuel fuel)
    {
        fuel.Value -= (int)(200 * IncreaseCoeff);
        return base.Power;
    }

    public override double GetNewFuelValue(Fuel fuel)
    {
        return fuel.Value * 0.2 * IncreaseCoeff;
    }
    
    public override void IncreastDelta()
    {
        IncreaseCoeff += 1;
    }
}