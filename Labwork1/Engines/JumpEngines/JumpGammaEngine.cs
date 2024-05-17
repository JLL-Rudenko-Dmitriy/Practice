using Labworks.Fuels;
namespace Labworks.Engines.JumpEngines;

public class JumpGammaEngine : Engine
{
    public JumpGammaEngine() : base(new ConstEnginesPowers().PowerJumpGamma)
    {
        IncreaseCoeff = 5.0;
    }
    

    public override void StartEngine(Fuel fuel)
    {
        IncreaseCoeff = 5.0;
        return; 
    }

    public override double GetCurrentPower(Fuel fuel)
    {
        fuel.Value -= (int)(200 * IncreaseCoeff);
        return base.Power;
    }

    public override double GetNewFuelValue(Fuel fuel)
    {
        return 0.2 * fuel.Value * IncreaseCoeff;
    }

    public override void IncreastDelta()
    {
        IncreaseCoeff += 1;
        IncreaseCoeff = double.Log2(IncreaseCoeff);
        return ;
    }
}