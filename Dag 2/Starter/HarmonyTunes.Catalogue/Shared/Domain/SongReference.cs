using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Shared.Domain;

public class SongReference : Identity
{
    public SongReference(Guid key) : base(key)
    {
    }
}
