namespace Labworks.Fuels;

public abstract class Fuel
{
    public int Value { get; set; }

    public Fuel(int value)
    {
        this.Value = value;
    }
}

