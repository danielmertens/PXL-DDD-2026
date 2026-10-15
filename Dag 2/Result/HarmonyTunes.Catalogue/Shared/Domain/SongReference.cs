using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Shared.Domain;

public class SongReference : Identity
{
    public SongReference(Guid key) : base(key)
    {
    }
}
