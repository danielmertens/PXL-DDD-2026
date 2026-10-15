using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Song.Domain.Events;

public class SongDataChanged : DomainEvent
{
    public required Url SongData { get; init; }

    protected override IEnumerable<object> GetValues()
    {
        yield return SongData;
    }
}
