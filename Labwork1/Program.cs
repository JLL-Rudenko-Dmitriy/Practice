using Labworks.Deflectors;
using Labworks.Deflectors.CurrentDeflectors;
using Labworks.Engines.ImpulseEngines;
using Labworks.Engines.JumpEngines;
using Labworks.Fuels;
using Labworks.HullStrengths.CurrentHullStregthClasses;
using Labworks.Obstacles;
using Labworks.Route;
using Labworks.Ships;
using Labworks.SpaceEnvironments;
    

var route = new Route(new List<ISpaceEnvironment>()
{
    new NitrineParticleNebulae(envDistance: 100, obstaclesCollection: new List<Obstacle>()
    {
        new SpaceWhale()
    }),
});

var shuttle = new Ship(new NitrineDecorator(new DeflectorClassTwo()), new HullStrengthClassTwo(), new ImpulseEEngine(),
    null, new ActivePlasmaFuel(1000),new GravityMatterFuel(1000));


route.LaunchSoloShip(shuttle);