namespace HarmonyTunes.Ports.Catalogue.Models;

public class CreateSongDto
{
    public Guid AlbumReference { get; set; }
    public required string Name { get; set; }
}
