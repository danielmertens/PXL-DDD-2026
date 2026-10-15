using HarmonyTunes.Catalogue.Artist.Application.Interfaces;
using HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Ports.Catalogue.Models;

namespace HarmonyTunes.Ports.Catalogue.Adapters.WebApi;

public static class ArtistController
{
    public static void RegisterControllers(WebApplication app)
    {
        app.MapPost("/api/artists/create", async (CreateArtistDto dto, IArtistService service) =>
        {
            var artistId = await service.Create(new ArtistIdentification(
                new LegalIdentification(
                    new Name(dto.LegalFirstName),
                    new Name(dto.LegalLastName),
                    dto.LegalMiddleNames.Select(name => new Name(name)).ToArray()),
                new StageIdentification(
                    new Name(dto.StageFirstName),
                    string.IsNullOrEmpty(dto.StageLastName) ? null : new Name(dto.StageLastName),
                    dto.StageMiddleNames.Select(name => new Name(name)).ToArray())));

            return new ArtistCreatedDto { ArtistReference = artistId.Key };
        });

        app.MapPost("/api/artists/{artistRef:guid}/billing/update", async (Guid artistRef, BillingInfoDto dto, IArtistService service) =>
        {
            await service.UpdateBillingInfo(
                new ArtistReference(artistRef),
                new BillingInfo(new Iban(dto.BankAccount), new Bic(dto.Bank), new Rate(dto.RatePerListen)));
        });
    }
}
