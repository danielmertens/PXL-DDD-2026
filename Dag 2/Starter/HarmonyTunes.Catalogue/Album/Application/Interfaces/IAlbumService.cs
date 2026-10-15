using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;

namespace HarmonyTunes.Catalogue.Album.Application.Interfaces;

public interface IAlbumService
{
    Task<AlbumReference> CreateAlbum(AlbumName albumName);
    Task ChangeDescription(AlbumReference albumReference, AlbumDescription description);
}
