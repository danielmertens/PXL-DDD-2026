using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain.Events;

public class AlbumLiked : DomainEvent
{
    public required TimeStamp TimeStamp { get; init; }

    protected override IEnumerable<object> GetValues()
    {
        yield return TimeStamp;
    }
}
