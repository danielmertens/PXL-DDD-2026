using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain.Events;

public class PublicationYearChanged : DomainEvent
{
    public required Year PublicationYear { get; init; }

    protected override IEnumerable<object> GetValues()
    {
        yield return PublicationYear;
    }
}
