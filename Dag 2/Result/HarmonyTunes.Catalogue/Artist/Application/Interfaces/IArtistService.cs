using HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;

namespace HarmonyTunes.Catalogue.Artist.Application.Interfaces;

public interface IArtistService
{
    Task<ArtistReference> Create(ArtistIdentification artistIdentification);
    Task UpdateBillingInfo(ArtistReference artistReference, BillingInfo billingInfo);
}