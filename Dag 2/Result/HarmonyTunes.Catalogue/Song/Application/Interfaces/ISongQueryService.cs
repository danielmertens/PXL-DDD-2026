using HarmonyTunes.Catalogue.Song.Application.Models;

namespace HarmonyTunes.Catalogue.Song.Application.Interfaces;

public interface ISongQueryService
{
    Task<IEnumerable<SongQueryModel>> GetAll();
    Task<SongQueryModel?> GetById(Guid id);
    Task<IEnumerable<SongQueryModel>> GetSongsByAlbum(Guid key);
}
