using HarmonyTunes.Catalogue.Artist.Application.Interfaces;
using HarmonyTunes.Catalogue.Artist.Domain;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core.Domain;
using HarmonyTunes.Ports.Catalogue.Adapters.Database.Shared;
using System.Text.Json;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Database.Artist;

public class ArtistRepository : IArtistRepository
{
    private readonly CatalogueContext _context;

    public ArtistRepository(CatalogueContext context)
    {
        _context = context;
    }

    public void Add(ArtistAggregate aggregate)
    {
        AggregateEntity aggregateEntity = new()
        {
            AggregateId = aggregate.Id.Key.ToString(),
            CurrentVersion = aggregate.Version,
        };

        _context.ArtistAggregate.Add(aggregateEntity);

        var version = 0;
        foreach (var evt in aggregate.Events)
        {
            version++;
            EventEntity eventEntity = CreateEventEntity(
                aggregate.Id.Key.ToString(),
                version,
                evt);
            _context.ArtistEventStore.Add(eventEntity);
        }
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public Task<ArtistAggregate> Fetch(ArtistReference identity)
    {
        var events = _context.ArtistEventStore
            .Where(x => x.AggregateId == identity.Key.ToString())
            .OrderBy(x => x.Version)
            .AsEnumerable()
            .Select(e => DeserializeEvent(e))
            .ToList();

        if (events.Count == 0) throw new Exception("Aggregate not found");

        return Task.FromResult(new ArtistAggregate(identity, events));
    }

    public ArtistReference GetNextIdentity()
    {
        return new ArtistReference(Guid.NewGuid());
    }

    public void Update(ArtistAggregate aggregate)
    {
        var dbAggregate = _context.ArtistAggregate.Find(aggregate.Id.Key.ToString());
        if (dbAggregate == null) throw new Exception("Aggregate not found");

        var originalVersion = dbAggregate.CurrentVersion;

        if (originalVersion != aggregate.Version - aggregate.Events.Count)
        {
            throw new Exception("Aggregate version doesn't match.");
        }

        var version = originalVersion;
        for (int i = 0; i < aggregate.Events.Count; i++)
        {
            version++;
            var eventEntity = CreateEventEntity(
                aggregate.Id.Key.ToString(),
                version,
                aggregate.Events[i]);

            _context.ArtistEventStore.Add(eventEntity);
        }

        dbAggregate.CurrentVersion = aggregate.Version;
    }

    private static EventEntity CreateEventEntity(string aggregateId, int version, IDomainEvent evt)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            AggregateId = aggregateId,
            Version = version,
            MessageType = evt.GetType().Name,
            EventData = JsonSerializer.Serialize(evt, evt.GetType())
        };
    }

    private static DomainEvent DeserializeEvent(EventEntity eventEntity)
    {
        var eventType = Type.GetType($"HarmonyTunes.Catalogue.Artist.Domain.Events.{eventEntity.MessageType}, HarmonyTunes.Catalogue")
            ?? throw new Exception($"Unknown event type '{eventEntity.MessageType}'.");
        var domainEventObject = JsonSerializer.Deserialize(eventEntity.EventData, eventType);
        return domainEventObject as DomainEvent
            ?? throw new Exception($"Event {eventEntity.Id} could not be read as {eventEntity.MessageType}.");
    }
}
