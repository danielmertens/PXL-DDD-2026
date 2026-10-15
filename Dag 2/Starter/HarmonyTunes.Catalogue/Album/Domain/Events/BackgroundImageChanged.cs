using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Album.Domain.Events;

public class BackgroundImageChanged : DomainEvent
{
    public required Url BackgroundImageUrl { get; init; }

    protected override IEnumerable<object> GetValues()
    {
        yield return BackgroundImageUrl;
    }
}
