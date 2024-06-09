namespace Labworks.Engines.JumpEngines;

public interface IJumpEngine: IEngine
{
    public bool CanJumpOver(double distance);
}