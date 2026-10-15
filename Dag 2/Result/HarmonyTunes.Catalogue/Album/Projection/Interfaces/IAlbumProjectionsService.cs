using HarmonyTunes.Catalogue.Shared.Domain;

namespace HarmonyTunes.Catalogue.Album.Projection.Interfaces;

public interface IAlbumProjectionsService
{
    Task OnAlbumUpdated(AlbumReference albumReference);
    Task OnSongCreated(AlbumReference albumReference);
}