using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Song.Domain.Exceptions;

public class SongNotCreated : DomainRuleViolation
{
    public SongNotCreated()
        : base("Can't change a song that isn't created yet.")
    {

    }
}
