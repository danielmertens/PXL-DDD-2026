using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Shared.Domain;

public class ArtistReference : Identity
{
    public ArtistReference(Guid key)
        : base(key)
    { }
}
