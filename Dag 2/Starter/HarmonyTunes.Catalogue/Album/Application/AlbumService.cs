using HarmonyTunes.Catalogue.Album.Application.Interfaces;
using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;

namespace HarmonyTunes.Catalogue.Album.Application;

public class AlbumService : IAlbumService
{
    public Task<AlbumReference> CreateAlbum(AlbumName albumName)
    {
        // TODO: create the aggregate, call Create(...) and persist it
        throw new NotImplementedException();
    }

    public Task ChangeDescription(AlbumReference albumReference, AlbumDescription description)
    {
        // TODO: fetch the aggregate, call ChangeDescription(...) and persist it
        throw new NotImplementedException();
    }
}
