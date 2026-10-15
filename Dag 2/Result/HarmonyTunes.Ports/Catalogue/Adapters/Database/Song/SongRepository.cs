using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Catalogue.Song.Application.Interfaces;
using HarmonyTunes.Catalogue.Song.Domain;
using Microsoft.EntityFrameworkCore;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Database.Song;

public class SongRepository : ISongRepository
{
    public const string DbKeyColumn = "SongId";
    public const string VersionColumn = "Version";
    private readonly CatalogueContext _context;

    public SongRepository(CatalogueContext context)
    {
        _context = context;
    }

    public void Add(SongAggregate aggregateRoot)
    {
        var state = aggregateRoot.CurrentState;
        _context.Entry(state).Property(DbKeyColumn).CurrentValue = aggregateRoot.Id.Key;
        _context.Entry(state).Property(VersionColumn).CurrentValue = aggregateRoot.Version;

        _context.Songs.Add(state);
    }

    public void Update(SongAggregate aggregateRoot)
    {
        if (aggregateRoot.Events.Any())
        {
            var state = aggregateRoot.CurrentState;
            _context.Entry(state).Property(DbKeyColumn).CurrentValue = aggregateRoot.Id.Key;
            _context.Entry(state).Property(VersionColumn).CurrentValue = aggregateRoot.Version;

            _context.Songs.Update(state);
        }
    }

    public async Task<SongAggregate> Fetch(SongReference id)
    {
        var state = await _context.Songs
            .Where(a => EF.Property<Guid>(a, DbKeyColumn) == id.Key)
            .SingleOrDefaultAsync();

        if (state == null) throw new Exception("Aggregate not found");

        var version = _context.Entry(state).Property<int>(VersionColumn).CurrentValue;
        return new SongAggregate(state, id, version);
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public SongReference GetNextIdentity()
    {
        return new SongReference(Guid.NewGuid());
    }
}
