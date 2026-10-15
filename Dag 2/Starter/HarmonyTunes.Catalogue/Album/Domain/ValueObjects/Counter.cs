using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Album.Domain.ValueObjects;

public class Counter : ValueObject
{
    public long Value { get; }

    public Counter(long value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);
        Value = value;
    }

    public Counter Increment()
    {
        return new Counter(Value + 1);
    }

    protected override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
