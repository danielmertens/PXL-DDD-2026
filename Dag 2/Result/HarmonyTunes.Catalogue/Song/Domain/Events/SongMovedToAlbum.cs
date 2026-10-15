using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Song.Domain.Events;

public class SongMovedToAlbum : DomainEvent
{
    public required AlbumReference AlbumId { get; init; }

    protected override IEnumerable<object> GetValues()
    {
        yield return AlbumId;
    }
}
