using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Catalogue.Song.Domain.ValueObjects;

namespace HarmonyTunes.Catalogue.Song.Application.Interfaces;

public interface ISongService
{
    Task<SongReference> Create(AlbumReference albumReference, SongName name);
}
