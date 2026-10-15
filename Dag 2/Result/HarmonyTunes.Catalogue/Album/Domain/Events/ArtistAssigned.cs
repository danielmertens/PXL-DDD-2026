using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain.Events;

public class ArtistAssigned : DomainEvent
{
    public required ArtistReference Artist { get; init; }

    protected override IEnumerable<object> GetValues()
    {
        yield return Artist;
    }
}
