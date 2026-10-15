using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain.ValueObjects;

public class Counter : ValueObject
{
    public long Value { get; }

    public Counter(long value)
    {
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
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
