using HarmonyTunes.Catalogue.Artist.Domain.Events;
using HarmonyTunes.Catalogue.Artist.Domain.Exceptions;
using HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Artist.Domain;

public class ArtistAggregate : AggregateRoot<ArtistState, ArtistReference>
{
    public ArtistAggregate(ArtistReference id) : base(id)
    {
    }

    public ArtistAggregate(ArtistReference id, IEnumerable<IDomainEvent> events) : base(id, events)
    {
    }

    public void Create(ArtistIdentification artistIdentification)
    {
        if (CurrentState.Identity is not null)
            throw new ArtistAlreadyCreated();

        RaiseEvent(new ArtistCreated
        {
            ArtistIdentification = artistIdentification
        });
    }

    public void UpdateBilling(BillingInfo billingInfo)
    {
        EnsureCreated();

        RaiseEvent(new BillingInfoUpdated
        {
            BillingInfo = billingInfo
        });
    }

    private void EnsureCreated()
    {
        if (CurrentState.Identity is null)
            throw new ArtistNotCreated();
    }
}
