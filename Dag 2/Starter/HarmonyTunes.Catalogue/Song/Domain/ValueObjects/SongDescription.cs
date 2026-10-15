using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Song.Domain.ValueObjects;

public class SongDescription : ValueObject
{
    public string Value { get; }

    public SongDescription(string value)
    {
        if (string.IsNullOrEmpty(value)) { throw new ArgumentException(nameof(value)); }
        Value = value;
    }

    protected override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
