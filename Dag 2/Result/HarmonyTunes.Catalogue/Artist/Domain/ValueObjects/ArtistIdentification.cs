namespace HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;

public record ArtistIdentification
{
    public LegalIdentification Legal { get; }
    public StageIdentification Stage { get; }

    public ArtistIdentification(LegalIdentification legal, StageIdentification stage)
    {
        ArgumentNullException.ThrowIfNull(legal);
        ArgumentNullException.ThrowIfNull(stage);

        Legal = legal;
        Stage = stage;
    }
}
