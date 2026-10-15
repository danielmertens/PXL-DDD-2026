namespace HarmonyTunes.Catalogue.Album.Projection.Models;

public class AlbumOverviewProjection
{
    public Guid Id { get; set; }
    public string AlbumName { get; set; } = string.Empty;
    public string ArtistName { get; set; } = string.Empty;
    public int NumberOfSongs { get; set; }
}
