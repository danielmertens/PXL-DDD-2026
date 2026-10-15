using HarmonyTunes.Catalogue.Artist.Domain.Events;
using HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Artist.Domain;

public class ArtistState : AggregateState
{
    public ArtistIdentification Identity { get; private set; } = null!;
    public BillingInfo Billing { get; private set; } = null!;

    public void When(ArtistCreated evt)
    {
        Identity = evt.ArtistIdentification;
    }

    public void When(BillingInfoUpdated evt)
    {
        Billing = evt.BillingInfo;
    }
}
