using HarmonyTunes.Catalogue.Album.Projection.Models;

namespace HarmonyTunes.Catalogue.Album.Projection.Interfaces;

public interface IAlbumProjectionsRepository
{
    void AddOrUpdateProjection(AlbumOverviewProjection projection);
    Task<IEnumerable<AlbumOverviewProjection>> GetAll();
    Task Commit();
}
