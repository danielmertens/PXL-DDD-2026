namespace HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;

public record Rate
{
    public decimal Value { get; }

    public Rate(decimal value)
    {
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
        Value = value;
    }
}
