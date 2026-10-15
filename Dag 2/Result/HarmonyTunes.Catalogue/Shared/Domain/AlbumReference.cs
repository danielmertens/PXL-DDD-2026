using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Shared.Domain;

public class AlbumReference : Identity
{
    public AlbumReference(Guid key) : base(key) { }
}
