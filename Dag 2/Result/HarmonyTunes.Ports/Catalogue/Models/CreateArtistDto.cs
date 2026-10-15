namespace HarmonyTunes.Ports.Catalogue.Models;

public class CreateArtistDto
{
    public required string LegalFirstName { get; set; }
    public required string LegalLastName { get; set; }
    public string[] LegalMiddleNames { get; set; } = [];
    public required string StageFirstName { get; set; }
    public string? StageLastName { get; set; }
    public string[] StageMiddleNames { get; set; } = [];
}
