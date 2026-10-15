using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Album.Domain.ValueObjects;

public class AlbumDescription : ValueObject
{
    public string Value { get; }

    public AlbumDescription(string value)
    {
        if (string.IsNullOrEmpty(value)) { throw new ArgumentException(nameof(value)); }
        Value = value;
    }

    protected override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
