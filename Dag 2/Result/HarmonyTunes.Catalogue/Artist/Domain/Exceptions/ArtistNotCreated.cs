using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Artist.Domain.Exceptions;

public class ArtistNotCreated : DomainRuleViolation
{
    public ArtistNotCreated()
        : base("Can't change an artist that isn't created yet.")
    {

    }
}
