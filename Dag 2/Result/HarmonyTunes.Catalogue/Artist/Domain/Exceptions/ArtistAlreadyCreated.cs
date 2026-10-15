using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Artist.Domain.Exceptions;

public class ArtistAlreadyCreated : DomainRuleViolation
{
    public ArtistAlreadyCreated()
        : base("Can't call create on an artist that's already created.")
    {

    }
}
