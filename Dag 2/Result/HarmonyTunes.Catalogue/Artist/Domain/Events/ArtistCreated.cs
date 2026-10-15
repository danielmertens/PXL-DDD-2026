using HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Artist.Domain.Events;

public class ArtistCreated : DomainEvent
{
    public required ArtistIdentification ArtistIdentification { get; init; }

    protected override IEnumerable<object> GetValues()
    {
        yield return ArtistIdentification;
    }
}