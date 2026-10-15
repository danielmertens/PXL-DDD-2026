using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain.Exceptions;

public class AlbumNotCreated : DomainRuleViolation
{
    public AlbumNotCreated()
        : base("Can't change an album that isn't created yet.")
    {

    }
}
