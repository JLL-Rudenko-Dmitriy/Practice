using System.Collections;
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
using Labworks.States;

namespace TestProject2;

public class TestAvgurWalkingShipInNebulaEnv : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator() 
    {
        yield return new object[] {new Ship(null, new HullStrengthClassOne(), new ImpulseCEngine(), null, null,
            new GravityMatterFuel(1000))};
        
        yield return new object[] {new Ship(null, new HullStrengthClassOne(), new ImpulseEEngine(), new JumpAlphaEngine(),
            new ActivePlasmaFuel(1000), new GravityMatterFuel(1000))};
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class TestVaclasesWithFotoneFlash : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new Ship(new DeflectorClassOne(), new HullStrengthClassTwo(), new ImpulseEEngine(), new JumpGammaEngine(),
                new ActivePlasmaFuel(1000), new GravityMatterFuel(1000)),
            ShipState.CrewDied
        };
        yield return new object[]
        {
            new Ship(new FotoneDecorator(new DeflectorClassOne()), new HullStrengthClassTwo(), new ImpulseEEngine(), new JumpGammaEngine(),
                new ActivePlasmaFuel(1000), new GravityMatterFuel(1000)),
            ShipState.Ok
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class TestAvgurVaklasMeredianInNithrineParticles : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] {new Ship(new DeflectorClassOne(), new HullStrengthClassTwo(), new ImpulseEEngine(), new JumpGammaEngine(),
            new ActivePlasmaFuel(1000), new GravityMatterFuel(1000)),
            ShipState.ShipDestroyed, DeflectorState.DeflectorDestroyed
        };
        yield return new object[]
        {
            new Ship(new DeflectorClassThree(), new HullStrengthClassThree(), new ImpulseEEngine(),
                new JumpAlphaEngine(), new ActivePlasmaFuel(10000),new GravityMatterFuel(10000)),
            ShipState.Ok,
            DeflectorState.DeflectorDestroyed
        };
        yield return new object[]
        {
            new Ship(new NitrineDecorator(new DeflectorClassTwo()), new HullStrengthClassTwo(), new ImpulseEEngine(),
                null, new ActivePlasmaFuel(10000),new GravityMatterFuel(10000)),
            ShipState.Ok,
            DeflectorState.Ok
        };

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class TestMySpaceShip
{
    [Theory]
    [ClassData(typeof(TestAvgurWalkingShipInNebulaEnv))]
    public void Test_Avgur_And_WalkingShip_In_Medium_Route(Ship ship)
    {
        var actual = ShipState.FuelEmpty;
        var route = new Route(new List<ISpaceEnvironment>()
        {
            new NebulaOfIncreasedDensity(envDistance: 9000, obstaclesCollection: new List<Obstacle>()
            {
                
            }),
        });
        
        route.LaunchSoloShip(ship);
        Assert.Equal(ship.ShipState, actual);
    }

    [Theory]
    [ClassData(typeof(TestVaclasesWithFotoneFlash))]
    public void Test_Vaklases_With_Fotone_Deflector_And_Without(Ship ship, ShipState actual)
    {
        var route = new Route(new List<ISpaceEnvironment>()
        {
            new NitrineParticleNebulae(envDistance: 100, obstaclesCollection: new List<Obstacle>()
            {
                new FotoneFlash()
            }),
        });
        route.LaunchSoloShip(ship);
        Assert.Equal(actual,ship.ShipState);
    }

    [Theory]
    [ClassData(typeof(TestAvgurVaklasMeredianInNithrineParticles))]
    public void Test_Avgur_Vaklas_Meredian_In_Nithrine_Particles(Ship ship, ShipState expectedShipState,
        DeflectorState expectedflectorState)
    {
        object[] expectedData = new object[]
        {
            expectedShipState,
            expectedflectorState
        };
        
        var route = new Route(new List<ISpaceEnvironment>()
        {
            new NitrineParticleNebulae(envDistance: 100, obstaclesCollection: new List<Obstacle>()
            {
               new SpaceWhale()
            }),
        });

        route.LaunchSoloShip(ship);
        object[] actualData = new object[]
        {
            ship.ShipState,
            ship.Deflector.GetStatus(),
        };

    Assert.Equal(expectedData, actualData);
    }


    [Fact] 
    public void Test_GetOptimal_On_Small_Distance_With_Vaklas_And_WalkingShuttle()
    {
        var Vaklas = new Ship(new DeflectorClassOne(), new HullStrengthClassTwo(), new ImpulseEEngine(),
            new JumpGammaEngine(),
            new ActivePlasmaFuel(1000), new GravityMatterFuel(1000));
        
        var WalkingShuttle = new Ship(null, new HullStrengthClassOne(), new ImpulseCEngine(), null, null,
            new GravityMatterFuel(1000));

        var route = new Route(new List<ISpaceEnvironment>()
        {
            new SimpleSpace(envDistance: 100, obstaclesCollection: new List<Obstacle>()
            {
                new SmallMeteor()
            })
        });

        var optimalShip = route.GetOptimal(shipOne: Vaklas, shipTwo: WalkingShuttle);
        Assert.Same(WalkingShuttle, optimalShip);
    }
    
    [Fact] 
    public void Test_GetOptimal_On_Medium_Distance_IncreasedNitrine_With_Avgur_And_Stella()
    {
        var Avgur = new Ship(new DeflectorClassThree(), new HullStrengthClassThree(), new ImpulseEEngine(),
            new JumpAlphaEngine(), new ActivePlasmaFuel(10000),new GravityMatterFuel(10000));
        
        var Stella = new Ship(new DeflectorClassOne(), new HullStrengthClassOne(), new ImpulseCEngine(), new JumpOmegaEngine(), new ActivePlasmaFuel(10000),
            new GravityMatterFuel(10000));

        var route = new Route(new List<ISpaceEnvironment>()
        {
            new NebulaOfIncreasedDensity(envDistance: 300, obstaclesCollection: new List<Obstacle>()
            {
                new SmallMeteor()
            })
        });

        var actualShip = route.GetOptimal(shipOne: Avgur, shipTwo: Stella, plasmaCost:100, gravityMatterCost:100);
        Assert.Same(Stella, actualShip);
    }
    
    [Fact] 
    public void Test_GetOptimal_On_Medium_Distance_Nitrine_With_Vaklas_And_WalkingShuttle()
    {
        var vaklas = new Ship(new DeflectorClassOne(), new HullStrengthClassTwo(), new ImpulseEEngine(),
            new JumpGammaEngine(),
            new ActivePlasmaFuel(1000), new GravityMatterFuel(1000));
        
        var walkingShuttle = new Ship(null, new HullStrengthClassOne(), new ImpulseCEngine(), null, null,
            new GravityMatterFuel(1000));

        var route = new Route(new List<ISpaceEnvironment>()
        {
            new NitrineParticleNebulae(envDistance: 500, obstaclesCollection: new List<Obstacle>()
            {
                new SmallMeteor()
            })
        });

        var actualShip = route.GetOptimal(shipOne: vaklas, shipTwo: walkingShuttle);
        Assert.Same(vaklas, actualShip);
    }

    [Fact]
    public void Test_My_Custom_Ship_With_All_Parts_OF_Env()
    {
        var superWalkingShuttle = new Ship(new NitrineDecorator(new FotoneDecorator(new DeflectorClassTwo())), new HullStrengthClassThree(),
            new ImpulseEEngine(), new JumpGammaEngine(), new ActivePlasmaFuel(100000), new GravityMatterFuel(10000));
        
        var route = new Route(new List<ISpaceEnvironment>()
        {
            new SimpleSpace(envDistance: 1000, obstaclesCollection: new List<Obstacle>()
            {
                new Meteorite()
            }),
            
            new NitrineParticleNebulae(envDistance:500, obstaclesCollection: new List<Obstacle>()
            {
                new SpaceWhale()
            }),
            
            new NebulaOfIncreasedDensity(envDistance:1000, obstaclesCollection: new List<Obstacle>()
            {
                new FotoneFlash()
            }),
        });
        ShipState expected = ShipState.Ok;
        route.LaunchSoloShip(superWalkingShuttle);
        
        Assert.Equal(expected, superWalkingShuttle.ShipState);
    }
}


