using Labworks.Deflectors;
using Labworks.Engines;
using Labworks.Engines.ImpulseEngines;
using Labworks.Engines.JumpEngines;
using Labworks.HullStrengths;
using Labworks.States;


namespace Labworks.Ships;

public class Ship
{
    public Deflector? Deflector { get; set;  }
    public HullStrengthClass HullStrengthClass { get; set; }
    
    public ShipState ShipState { get; set; } = ShipState.Ok;

    public Engine? ImpulseEngine { get; set; }
    public Engine? JumpEngine { get; set; }


    public Ship(Deflector? deflector, HullStrengthClass hullStrengthClass, Engine? impulseEngine, Engine? jumpEngine)
    {
        Deflector = deflector;
        HullStrengthClass = hullStrengthClass;
        ImpulseEngine = impulseEngine;
        JumpEngine = jumpEngine;
        if ((ImpulseEngine is null) && (JumpEngine is null))
        {
            throw new ArgumentException("Must have at least one engine");
        }
    }
    
}