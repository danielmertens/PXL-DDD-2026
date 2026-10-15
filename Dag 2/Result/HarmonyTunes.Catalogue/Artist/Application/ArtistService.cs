using HarmonyTunes.Catalogue.Artist.Application.Interfaces;
using HarmonyTunes.Catalogue.Artist.Domain;
using HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core.Application;

namespace HarmonyTunes.Catalogue.Artist.Application;

public class ArtistService : ApplicationService<ArtistAggregate, ArtistState, ArtistReference>, IArtistService
{
    public ArtistService(IArtistRepository repository)
        : base(repository)
    {

    }

    public async Task<ArtistReference> Create(ArtistIdentification artistIdentification)
    {
        return await Add(agg => agg.Create(artistIdentification));
    }

    public async Task UpdateBillingInfo(ArtistReference artistReference, BillingInfo billingInfo)
    {
        await Update(artistReference,
            agg => agg.UpdateBilling(billingInfo));
    }
}
