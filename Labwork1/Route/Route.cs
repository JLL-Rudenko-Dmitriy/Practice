using Labworks.Ships;
using Labworks.SpaceEnvironments;
using Labworks.States;

namespace Labworks.Route;

public class Route
{
    public IEnumerable<ISpaceEnvironment> EnvironmentsList { get; set; }
    public Route( IEnumerable<ISpaceEnvironment> environmentsList)
    {
        this.EnvironmentsList = environmentsList;
    }

    public void LaunchSoloShip(Ship currentShip)
    {
        foreach (ISpaceEnvironment environment in EnvironmentsList)
        {
            currentShip.TryToReach(environment);
            if (currentShip.ShipState != ShipState.Ok)
            {
                Console.WriteLine($"{currentShip.GetType().FullName} is not finished the route");
                PrintShipInfo(currentShip);
                return ;
            }
        }
        Console.WriteLine($"{currentShip.GetType().FullName} finishing route");
        PrintShipInfo(currentShip);
    }

    public void LaunchShips(IEnumerable<Ship> shipList)
    {
        foreach (Ship ship in shipList)
        {
            LaunchSoloShip(ship);
        }
    }

    public Ship GetOptimal(Ship shipOne, Ship shipTwo, int plasmaCost= 200, int gravityMatterCost= 120)
    {
        double startFuelValueGravityShipOne = shipOne.GravityFuel != null ? shipOne.GravityFuel.Value : 0;
        double startFuelValuePlasmaShipOne = shipOne.PlasmaFuel != null ? shipOne.PlasmaFuel.Value : 0;
        
        double startFuelValueGravityShipTwo = shipTwo.GravityFuel != null ? shipTwo.GravityFuel.Value : 0;
        double startFuelValuePlasmaShipTwo = shipTwo.PlasmaFuel != null ? shipTwo.PlasmaFuel.Value : 0;
        
        LaunchShips(new List<Ship>(){shipOne,shipTwo});
        
        double endFuelValueGravityShipOne = shipOne.GravityFuel != null ? shipOne.GravityFuel.Value : 0;
        double endFuelValuePlasmaShipOne = shipOne.PlasmaFuel != null ? shipOne.PlasmaFuel.Value : 0;
        
        double endFuelValueGravityShipTwo = shipTwo.GravityFuel != null ? shipTwo.GravityFuel.Value : 0;
        double endFuelValuePlasmaShipTwo = shipTwo.PlasmaFuel != null ? shipTwo.PlasmaFuel.Value : 0;
        if ((shipOne.ShipState == shipTwo.ShipState) && (shipOne.ShipState == ShipState.Ok))
        {
            var optimalShip = shipOne;
            int fuelCostsShipOne = (int)(startFuelValueGravityShipOne - endFuelValueGravityShipOne) * gravityMatterCost +
                                 (int)(startFuelValuePlasmaShipOne - endFuelValuePlasmaShipOne) * plasmaCost;
            
            int fuelCostsShipTwo = (int)(startFuelValueGravityShipTwo - endFuelValueGravityShipTwo) * gravityMatterCost +
                                   (int)(startFuelValuePlasmaShipTwo - endFuelValuePlasmaShipTwo) * plasmaCost;

            if (fuelCostsShipOne > fuelCostsShipTwo)
            {
                optimalShip = shipTwo;
            }

            return optimalShip;
        } else if (shipOne.ShipState != shipTwo.ShipState)
        {
            if (shipOne.ShipState == ShipState.Ok)
            {
                return shipOne;
            } else if (shipTwo.ShipState == ShipState.Ok)
            {
                return shipTwo;
            }
        }
        return null;
    }
    
    public void PrintShipInfo(Ship currentShip)
    {
        String shipResult = "";
        shipResult += $"Ship state is {currentShip.ShipState}\n";
        shipResult += $"ClassHullStatus: {currentShip.HullStrengthClass.GetStatus()}\n";
        
        if (currentShip.PlasmaFuel is not null)
        {
            shipResult += $"Plasma fuel: {currentShip.PlasmaFuel.Value}\n";
        }

        if (currentShip.GravityFuel != null)
        {
            shipResult += $"Gravity fuel:{currentShip.GravityFuel.Value}\n";
        }

        if (currentShip.Deflector != null)
        {
            shipResult += $"DeflectorStatus: {currentShip.Deflector.GetStatus()}\n";
        }
        
        Console.WriteLine(shipResult);
    }
}