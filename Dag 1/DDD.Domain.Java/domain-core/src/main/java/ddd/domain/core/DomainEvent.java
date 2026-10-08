package ddd.domain.core;

/**
 * Marker for domain events: an immutable fact that happened in the domain, named in the past tense.
 *
 * <p>Implement events as records, and group the events of one aggregate under a {@code sealed}
 * interface. The compiler then knows every event the aggregate can raise, which lets the
 * {@link AggregateState} handle them with an exhaustive {@code switch}:
 *
 * <pre>{@code
 * public sealed interface UserEvent extends DomainEvent
 *         permits UserRegistered, UsernameChanged {
 * }
 *
 * public record UserRegistered(UserId id, String username) implements UserEvent {
 * }
 * }</pre>
 */
public interface DomainEvent extends ValueObject {
}
