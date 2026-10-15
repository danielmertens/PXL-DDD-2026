using HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Artist.Domain.Events;

public class BillingInfoUpdated : DomainEvent
{
    public required BillingInfo BillingInfo { get; init; }

    protected override IEnumerable<object> GetValues()
    {
        yield return BillingInfo;
    }
}