using HarmonyTunes.Catalogue.Album.Application.Interfaces;
using HarmonyTunes.Catalogue.Album.Application.Models;
using HarmonyTunes.Catalogue.Album.Domain;
using Microsoft.EntityFrameworkCore;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Database.Album;

public class AlbumQueryService : IAlbumQueryService
{
    private readonly CatalogueContext _context;

    public AlbumQueryService(CatalogueContext context)
    {
        _context = context;
    }

    public async Task<AlbumQueryModel?> GetById(Guid id)
    {
        var album = await _context.Albums
            .Where(a => EF.Property<Guid>(a, AlbumRepository.DbKeyColumn) == id)
            .SingleOrDefaultAsync();

        if (album == null) return null;

        return Map(album);
    }

    public async Task<IEnumerable<AlbumQueryModel>> GetAll()
    {
        var albums = await _context.Albums
            .ToListAsync();

        return albums.Select(album => Map(album)).ToList();
    }

    private AlbumQueryModel Map(AlbumState album)
    {
        return new AlbumQueryModel
        {
            Id = _context.Entry(album).Property<Guid>(AlbumRepository.DbKeyColumn).CurrentValue,
            ArtistId = album.Artist?.Key,
            Name = album.Name.Value,
            Description = album.Description?.Value,
            BackgroundUrl = album.BackgroundImageUrl?.Value,
            PublicationYear = album.PublicationYear?.Value,
            Likes = album.Likes.Value,
            Status = (int)album.Status
        };
    }
}
