using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Domain.Core.Application;

public interface IRepository<TAggregate, TState, TIdentity>
    where TAggregate : AggregateRoot<TState, TIdentity>
    where TState : AggregateState, new()
    where TIdentity : Identity
{
    void Add(TAggregate aggregate);
    void Update(TAggregate aggregate);
    Task<TAggregate> Fetch(TIdentity identity);
    Task Commit();
    public TIdentity GetNextIdentity();
}
