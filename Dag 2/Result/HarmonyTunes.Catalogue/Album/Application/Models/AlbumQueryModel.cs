namespace HarmonyTunes.Catalogue.Album.Application.Models;

public class AlbumQueryModel
{
    public Guid Id { get; set; }
    public Guid? ArtistId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? BackgroundUrl { get; set; }
    public int? PublicationYear { get; set; }
    public long Likes { get; set; }
    public int Status { get; set; }
}
