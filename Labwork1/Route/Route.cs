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
            if (coverInfo is WalkThroughResult.Success success)
            {
                finalDistance += environment.Distance;
                finalTime += success.Time;
                finalPlasmaFuel += success.PlasmaFuelValue;
                finalGravityFuel += success.GravityFuelValue;
            }
            else
            {
                return new RouteData(Status:coverInfo.ToString(), 0, 0, 0, 0);
            }
        }

        return new RouteData("Success", finalPlasmaFuel, finalGravityFuel,finalTime, finalDistance);
    }
}