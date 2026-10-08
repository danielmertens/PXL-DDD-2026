package ddd.domain.core;

/**
 * Marker for value objects: immutable, without identity, and equal when all their values are equal.
 *
 * <p>Implement value objects as {@code record}s. A record is immutable and gets value-based
 * {@code equals}, {@code hashCode} and {@code toString} from the compiler, so no base class is needed.
 * Guard the invariants in the compact constructor, so an invalid value object can never exist:
 *
 * <pre>{@code
 * public record EmailAddress(String value) implements ValueObject {
 *     public EmailAddress {
 *         if (value == null || !value.contains("@")) {
 *             throw new InvalidEmailAddress(value);
 *         }
 *     }
 * }
 * }</pre>
 *
 * <p>Records are only shallowly immutable: copy mutable components such as lists in the compact
 * constructor ({@code items = List.copyOf(items);}).
 */
public interface ValueObject {
}
