namespace HarmonyTunes.Domain.Core;

public abstract class AggregateState
{
    public abstract void Mutate(IDomainEvent evt);
}
