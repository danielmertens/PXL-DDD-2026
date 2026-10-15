using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain.ValueObjects;

public class Year : ValueObject
{
    public int Value { get; }

    public Year(int value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(value, 1900);
        Value = value;
    }

    protected override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
