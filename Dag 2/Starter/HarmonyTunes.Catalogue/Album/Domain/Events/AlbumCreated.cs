using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Album.Domain.Events;

public class AlbumCreated : DomainEvent
{
    public required AlbumName AlbumName { get; init; }

    protected override IEnumerable<object> GetValues()
    {
        yield return AlbumName;
    }
}