namespace HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;

public record Name
{
    public string Value { get; }

    public Name(string value)
    {
        if (string.IsNullOrEmpty(value)) { throw new ArgumentException(nameof(value)); }
        Value = value;
    }
}
