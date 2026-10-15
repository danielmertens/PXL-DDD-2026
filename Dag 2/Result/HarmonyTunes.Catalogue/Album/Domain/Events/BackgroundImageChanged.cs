using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain.Events;

public class BackgroundImageChanged : DomainEvent
{
    public required Url BackgroundImageUrl { get; init; }

    protected override IEnumerable<object> GetValues()
    {
        yield return BackgroundImageUrl;
    }
}
