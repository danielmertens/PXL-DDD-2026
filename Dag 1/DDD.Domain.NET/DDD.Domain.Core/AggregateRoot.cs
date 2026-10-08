namespace DDD.Domain.Core;

public abstract class AggregateRoot<TState, TId> where TState : AggregateState, new() where TId : Identity
{
    private readonly List<IDomainEvent> _events = new();

    public IReadOnlyList<IDomainEvent> Events => _events;
    public TState CurrentState { get; init; }
    public TId Id { get; init; }
    public int Version { get; private set; }

    protected AggregateRoot(TId id)
    {
        Id = id;
        CurrentState = new TState();
    }

    protected AggregateRoot(TState currentState, TId id, int version)
    {
        CurrentState = currentState;
        Id = id;
        Version = version;
    }

    protected void RaiseEvent(IDomainEvent evt)
    {
        if (evt is null)
        {
            throw new ArgumentNullException(nameof(evt));
        }

        CurrentState.Mutate(evt);
        _events.Add(evt);
        Version++;
    }
}