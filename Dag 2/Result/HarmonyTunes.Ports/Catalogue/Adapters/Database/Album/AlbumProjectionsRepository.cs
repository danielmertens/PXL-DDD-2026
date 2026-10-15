using HarmonyTunes.Catalogue.Album.Projection.Interfaces;
using HarmonyTunes.Catalogue.Album.Projection.Models;
using Microsoft.EntityFrameworkCore;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Database.Album;

public class AlbumProjectionsRepository : IAlbumProjectionsRepository
{
    private readonly CatalogueContext _context;

    public AlbumProjectionsRepository(CatalogueContext context)
    {
        _context = context;
    }

    public void AddOrUpdateProjection(AlbumOverviewProjection projection)
    {
        var dbProjection = _context.AlbumOverviewProjection.Find(projection.Id);

        if (dbProjection == null)
        {
            _context.AlbumOverviewProjection.Add(projection);
        }
        else
        {
            _context.Entry(dbProjection).CurrentValues.SetValues(projection);
        }
    }

    public async Task<IEnumerable<AlbumOverviewProjection>> GetAll()
    {
        return await _context.AlbumOverviewProjection
            .ToListAsync();
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}
