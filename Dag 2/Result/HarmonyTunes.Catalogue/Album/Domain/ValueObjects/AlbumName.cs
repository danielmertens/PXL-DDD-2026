using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain.ValueObjects;

public class AlbumName : ValueObject
{
    public string Value { get; }

    public AlbumName(string value)
    {
        if (string.IsNullOrEmpty(value)) { throw new ArgumentException(nameof(value)); }
        Value = value;
    }

    protected override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
