using HarmonyTunes.Catalogue.Album.Application.Models;

namespace HarmonyTunes.Catalogue.Album.Application.Interfaces;

public interface IAlbumQueryService
{
    Task<IEnumerable<AlbumQueryModel>> GetAll();
    Task<AlbumQueryModel?> GetById(Guid id);
}
