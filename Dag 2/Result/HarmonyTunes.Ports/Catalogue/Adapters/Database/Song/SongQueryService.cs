using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Catalogue.Song.Application.Interfaces;
using HarmonyTunes.Catalogue.Song.Application.Models;
using HarmonyTunes.Catalogue.Song.Domain;
using Microsoft.EntityFrameworkCore;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Database.Song;

public class SongQueryService : ISongQueryService
{
    private readonly CatalogueContext _context;

    public SongQueryService(CatalogueContext context)
    {
        _context = context;
    }

    public async Task<SongQueryModel?> GetById(Guid id)
    {
        var song = await _context.Songs
            .Where(a => EF.Property<Guid>(a, SongRepository.DbKeyColumn) == id)
            .SingleOrDefaultAsync();

        if (song == null) return null;

        return Map(song);
    }

    public async Task<IEnumerable<SongQueryModel>> GetAll()
    {
        var songs = await _context.Songs
            .ToListAsync();

        return songs.Select(s => Map(s)).ToList();
    }

    public async Task<IEnumerable<SongQueryModel>> GetSongsByAlbum(Guid albumId)
    {
        var albumReference = new AlbumReference(albumId);
        var songs = await _context.Songs
            .Where(s => s.AlbumId.Equals(albumReference))
            .ToListAsync();

        return songs.Select(s => Map(s)).ToList();
    }

    private SongQueryModel Map(SongState song)
    {
        return new SongQueryModel
        {
            Id = _context.Entry(song).Property<Guid>(SongRepository.DbKeyColumn).CurrentValue,
            AlbumId = song.AlbumId.Key,
            Name = song.Name.Value,
            Description = song.Description?.Value,
            Data = song.SongData?.Value
        };
    }
}
