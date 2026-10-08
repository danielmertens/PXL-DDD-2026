package ddd.domain.core;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Objects;

/**
 * Base class for aggregate roots. Commands are public methods that check the domain rules and then
 * {@link #raiseEvent raise an event}; the event mutates the {@link AggregateState}.
 *
 * <pre>{@code
 * public final class User extends AggregateRoot<UserId, UserEvent, UserState> {
 *
 *     public User(UserId id, String username) {
 *         super(id, new UserState());
 *         if (username == null || username.isBlank()) {
 *             throw new UsernameRequired();
 *         }
 *         raiseEvent(new UserRegistered(id, username));
 *     }
 *
 *     public void changeUsername(String newUsername) { ... }
 * }
 * }</pre>
 *
 * @param <ID> the identity of the aggregate
 * @param <E>  the (sealed) event type of the aggregate
 * @param <S>  the state of the aggregate
 */
public abstract class AggregateRoot<ID extends Identity, E extends DomainEvent, S extends AggregateState<E>> {

    private final ID id;
    private final S currentState;
    private final List<E> events = new ArrayList<>();
    private int version;

    /** Creates a new aggregate, starting from an empty state. */
    protected AggregateRoot(ID id, S initialState) {
        this(id, initialState, 0);
    }

    /** Restores an existing aggregate from its stored state and version. */
    protected AggregateRoot(ID id, S currentState, int version) {
        if (version < 0) {
            throw new IllegalArgumentException("Version can't be negative");
        }
        this.id = Objects.requireNonNull(id, "id");
        this.currentState = Objects.requireNonNull(currentState, "currentState");
        this.version = version;
    }

    public ID id() {
        return id;
    }

    public S currentState() {
        return currentState;
    }

    public int version() {
        return version;
    }

    /** The events raised on this instance, in order. Read-only. */
    public List<E> events() {
        return Collections.unmodifiableList(events);
    }

    protected final void raiseEvent(E event) {
        Objects.requireNonNull(event, "event");

        currentState.when(event);
        events.add(event);
        version++;
    }
}
