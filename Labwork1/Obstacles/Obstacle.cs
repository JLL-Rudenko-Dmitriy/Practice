using Labworks.DamageTypes;

namespace Labworks.Obstacles;

public abstract class Obstacle
{
    public DamageType DamageType { get; set; }
    public abstract int GiveDamage();
}

public class SmallMeteor : Obstacle
{
    public SmallMeteor()
    {
        DamageType = new DamageType();
    }

    public override int GiveDamage()
    {
        return base.DamageType.SmallDamage;
    }
}

public class Meteorite : Obstacle
{
    public Meteorite()
    {
        DamageType = new DamageType();
    }
    public override int GiveDamage()
    {
        return DamageType.MediumDamage;
    }
}

public class SpaceWhale : Obstacle
{
    public SpaceWhale()
    {
        DamageType = new DamageType();
    }
    public override int GiveDamage()
    {
        return DamageType.HugeDamage;
    }
}

public class FotoneFlash : Obstacle
{
    public FotoneFlash()
    {
        DamageType = new DamageType();
    }
    public override int GiveDamage()
    {
        return DamageType.FotoneDamage;
    }
}


