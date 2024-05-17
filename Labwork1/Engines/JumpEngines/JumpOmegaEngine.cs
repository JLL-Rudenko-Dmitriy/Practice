using Labworks.Fuels;
namespace Labworks.Engines.JumpEngines;

public class JumpOmegaEngine : Engine
{
    public JumpOmegaEngine() : base(new ConstEnginesPowers().PowerJumpOmega)
    {
        IncreaseCoeff = 1.0;
    }

    public override void StartEngine(Fuel fuel)
    {
        IncreaseCoeff = 1.0;
        return; 
    }

    public override double GetCurrentPower(Fuel fuel)
    {
        fuel.Value -= (int)(200 * IncreaseCoeff);
        return base.Power;
    }

    public override double GetNewFuelValue(Fuel fuel)
    {
        throw new NotImplementedException();
    }

    public override void IncreastDelta()
    {
        IncreaseCoeff += 1;
        IncreaseCoeff = double.Pow(2,IncreaseCoeff);
        return ;
    }
}