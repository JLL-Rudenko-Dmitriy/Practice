using Labworks.Ships;
using Labworks.SpaceEnvironments;

namespace Labworks.Route;

public class Route
{
    private List<IEnvironment> Environments { get; init; }

    public Route(IEnumerable<IEnvironment> environments)
    {
        Environments = environments.ToList();
    }
    
    public RouteData Calculate(Ship ship)
    {
        double finalTime = 0;
        double finalDistance = 0;
        double finalPlasmaFuel = 0;
        double finalGravityFuel = 0;
        
        foreach (var environment in Environments)
        {
            var coverInfo = environment.LaunchShip(ship);
            if (coverInfo.Status != "Covered")
            {
                return new RouteData(coverInfo.Status, finalPlasmaFuel, finalGravityFuel, finalTime, finalDistance);
            }
            finalDistance += environment.Distance;
            finalTime += coverInfo.Time;
            finalPlasmaFuel += coverInfo.PlasmaFuelValue;
            finalGravityFuel += coverInfo.GravityFuelValue;
        }

        return new RouteData("Covered", finalPlasmaFuel, finalGravityFuel, finalTime, finalDistance);
    }
}