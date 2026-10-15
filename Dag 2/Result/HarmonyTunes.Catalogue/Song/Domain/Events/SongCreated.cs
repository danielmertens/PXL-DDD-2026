using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Catalogue.Song.Domain.ValueObjects;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Song.Domain.Events;

public class SongCreated : DomainEvent
{
    public required AlbumReference AlbumId { get; init; }
    public required SongName Name { get; init; }

    protected override IEnumerable<object> GetValues()
    {
        yield return AlbumId;
        yield return Name;
    }
}