namespace DDD.Domain.Core;

public abstract class AggregateState
{
    public void Mutate(IDomainEvent evt)
    {
        ((dynamic)this).When((dynamic)evt);
    }
}
