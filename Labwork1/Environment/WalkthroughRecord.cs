namespace Labworks.SpaceEnvironments;


public record WalkThroughResult
{
    private WalkThroughResult() {}
    public sealed record Success (double PlasmaFuelValue, double GravityFuelValue, double Time): WalkThroughResult;
    public sealed record CrewDie() : WalkThroughResult;
    public sealed record InvalidEngine() : WalkThroughResult;
    public sealed record Destroyed() : WalkThroughResult;

    public sealed record LowJumpDistance() : WalkThroughResult;

}

