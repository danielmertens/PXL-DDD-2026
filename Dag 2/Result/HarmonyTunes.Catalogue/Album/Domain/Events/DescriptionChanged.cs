using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain.Events;

public class DescriptionChanged : DomainEvent
{
    public required AlbumDescription Description { get; init; }

    protected override IEnumerable<object> GetValues()
    {
        yield return Description;
    }
}
