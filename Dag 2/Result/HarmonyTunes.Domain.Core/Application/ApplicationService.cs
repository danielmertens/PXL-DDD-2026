using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Domain.Core.Application;

public abstract class ApplicationService<TAggregate, TState, TIdentity>
    where TAggregate : AggregateRoot<TState, TIdentity>
    where TState : AggregateState, new()
    where TIdentity : Identity
{
    private readonly IRepository<TAggregate, TState, TIdentity> _repository;

    public ApplicationService(IRepository<TAggregate, TState, TIdentity> repository)
    {
        _repository = repository;
    }

    public async Task<TIdentity> Add(Action<TAggregate> action)
    {
        var identity = _repository.GetNextIdentity();
        TAggregate aggregateRoot = (TAggregate)Activator.CreateInstance(typeof(TAggregate), identity)!;

        action(aggregateRoot);

        _repository.Add(aggregateRoot);
        await _repository.Commit();

        return identity;
    }

    public async Task Update(TIdentity identity, Action<TAggregate> action)
    {
        var aggregateRoot = await _repository.Fetch(identity);

        action(aggregateRoot);

        _repository.Update(aggregateRoot);
        await _repository.Commit();
    }

    public async Task<TIdentity> Add(Func<TAggregate, Task> action)
    {
        var identity = _repository.GetNextIdentity();
        TAggregate aggregateRoot = (TAggregate)Activator.CreateInstance(typeof(TAggregate), identity)!;

        await action(aggregateRoot);

        _repository.Add(aggregateRoot);
        await _repository.Commit();

        return identity;
    }

    public async Task Update(TIdentity identity, Func<TAggregate, Task> action)
    {
        var aggregateRoot = await _repository.Fetch(identity);

        await action(aggregateRoot);

        _repository.Update(aggregateRoot);
        await _repository.Commit();
    }
}
