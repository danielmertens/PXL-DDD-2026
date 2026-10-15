namespace HarmonyTunes.Catalogue.Song.Application.Models;

public class SongQueryModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid AlbumId { get; set; }
    public string? Data { get; set; }
}
