using HarmonyTunes.Catalogue.Song.Domain.ValueObjects;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Song.Domain.Events;

public class SongRenamed : DomainEvent
{
    public required SongName Name { get; init; }

    protected override IEnumerable<object> GetValues()
    {
        yield return Name;
    }
}
