namespace Labworks.DamageTypes;

public record DamageType
{
    public int SmallDamage { get; }
    public int MediumDamage { get; }
    public int HugeDamage { get; }
    public int FotoneDamage { get; }

    public DamageType()
    {
        SmallDamage = 4;
        MediumDamage = 20;
        HugeDamage = 80;
        FotoneDamage = 0;
    }
}

