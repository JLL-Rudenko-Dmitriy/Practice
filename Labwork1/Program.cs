    
using Labworks.Deflectors;
using Labworks.Deflectors.CurrentDeflectors;
using Labworks.Engines.ImpulseEngines;
using Labworks.Engines.JumpEngines;
using Labworks.HullStrengths.CurrentHullStregthClasses;
using Labworks.Obstacles;
using Labworks.Route;
using Labworks.Ships;
using Labworks.SpaceEnvironments;

var route = new Route(
    new List<IEnvironment>()
    {
        new SimpleSpace(100, new List<ISpaceObstacle>()
        {
            new SmallMeteor()
        }),
        new SimpleSpace(1000, new List<ISpaceObstacle>()
        {
            new Meteorite()
        }),
        new IncreaseDensity(10000, new List<IIncreaseDensityObstacle>()
        {
            new FotoneFlash()
        })
    });

var ship = new Ship(new FotoneDecorator( new DeflectorClassOne()), new HullStrengthClassOne(), new ImpulseCEngine(), new JumpAlphaEngine());

var result = route.Calculate(ship);

Console.WriteLine(result.ToString());
    
    // OUTPUT: RouteData { Status = Covered, PlasmaFuel = 11000, GravityFuel = 0,46875, FinalTime = 91,68619791666666, FinalDistance = 1110 }