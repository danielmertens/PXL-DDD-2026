using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain.ValueObjects;

public class TimeStamp : ValueObject
{
    public DateTime Value { get; }

    public TimeStamp(DateTime value)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(value, default);
        Value = value;
    }

    protected override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
