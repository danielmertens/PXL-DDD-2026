using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain.Events;

public class AlbumPublished : DomainEvent
{
    protected override IEnumerable<object> GetValues()
    {
        return Array.Empty<object>();
    }
}