using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Song.Domain.ValueObjects;

public class SongName : SingleValueObject<string>
{
    public SongName(string value) : base(value)
    {
        if (string.IsNullOrEmpty(value)) { throw new ArgumentException(nameof(value)); }
    }
}