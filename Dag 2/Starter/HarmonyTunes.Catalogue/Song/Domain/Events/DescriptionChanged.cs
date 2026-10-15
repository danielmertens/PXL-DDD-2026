using HarmonyTunes.Catalogue.Song.Domain.ValueObjects;
using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Song.Domain.Events;

public class DescriptionChanged : DomainEvent
{
    public required SongDescription Description { get; init; }

    protected override IEnumerable<object> GetValues()
    {
        yield return Description;
    }
}
