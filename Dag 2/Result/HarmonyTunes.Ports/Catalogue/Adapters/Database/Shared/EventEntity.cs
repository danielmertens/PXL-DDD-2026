namespace HarmonyTunes.Ports.Catalogue.Adapters.Database.Shared;

public class EventEntity
{
    public Guid Id { get; set; }

    public string AggregateId { get; set; } = string.Empty;

    public int Version { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public string MessageType { get; set; } = string.Empty;

    public string EventData { get; set; } = string.Empty;
}
