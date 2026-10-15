using HarmonyTunes.Catalogue.Album.Application.Interfaces;
using HarmonyTunes.Catalogue.Album.Domain;
using HarmonyTunes.Catalogue.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Database.Album;

public class AlbumRepository : IAlbumRepository
{
    public const string DbKeyColumn = "AlbumId";
    public const string VersionColumn = "Version";
    private readonly CatalogueContext _context;

    public AlbumRepository(CatalogueContext context)
    {
        _context = context;
    }

    public void Add(AlbumAggregate aggregateRoot)
    {
        var state = aggregateRoot.CurrentState;
        _context.Entry(state).Property(DbKeyColumn).CurrentValue = aggregateRoot.Id.Key;
        _context.Entry(state).Property(VersionColumn).CurrentValue = aggregateRoot.Version;

        _context.Albums.Add(state);
    }

    public void Update(AlbumAggregate aggregateRoot)
    {
        if (aggregateRoot.Events.Any())
        {
            var state = aggregateRoot.CurrentState;
            _context.Entry(state).Property(DbKeyColumn).CurrentValue = aggregateRoot.Id.Key;
            _context.Entry(state).Property(VersionColumn).CurrentValue = aggregateRoot.Version;

            _context.Albums.Update(state);
        }
    }

    public async Task<AlbumAggregate> Fetch(AlbumReference id)
    {
        var state = await _context.Albums
            .Where(a => EF.Property<Guid>(a, DbKeyColumn) == id.Key)
            .SingleOrDefaultAsync();

        if (state == null) throw new Exception("Aggregate not found");

        var version = _context.Entry(state).Property<int>(VersionColumn).CurrentValue;
        return new AlbumAggregate(state, id, version);
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public AlbumReference GetNextIdentity()
    {
        return new AlbumReference(Guid.NewGuid());
    }
}
