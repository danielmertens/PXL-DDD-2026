package ddd.domain.core;

/**
 * The state of an aggregate. The state changes only by applying the events of that aggregate.
 *
 * <p>Implement {@link #when} with a {@code switch} over the aggregate's sealed event interface. Because
 * the switch is exhaustive, forgetting to handle a new event is a compile error instead of a runtime one:
 *
 * <pre>{@code
 * public final class UserState extends AggregateState<UserEvent> {
 *     private String username;
 *
 *     public String username() {
 *         return username;
 *     }
 *
 *     @Override
 *     protected void when(UserEvent event) {
 *         switch (event) {
 *             case UserRegistered e -> username = e.username();
 *             case UsernameChanged e -> username = e.newUsername();
 *         }
 *     }
 * }
 * }</pre>
 *
 * <p>Keep {@link #when} {@code protected} and don't add public setters: then only the
 * {@link AggregateRoot} can change the state, and only through events.
 *
 * @param <E> the (sealed) event type of the aggregate
 */
public abstract class AggregateState<E extends DomainEvent> {

    /**
     * Applies an event that has already happened. Don't validate domain rules here: the aggregate
     * checks the rules before it raises the event.
     */
    protected abstract void when(E event);
}
