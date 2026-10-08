package ddd.domain.core;

import java.util.UUID;

/**
 * Strongly typed identity of an entity or aggregate. An identity is a value object wrapping a {@link UUID}.
 *
 * <p>Give every aggregate its own identity record, so a {@code UserId} can never be passed where a
 * {@code SongId} is expected:
 *
 * <pre>{@code
 * public record UserId(UUID key) implements Identity {
 *     public UserId {
 *         Identity.requireValid(key);
 *     }
 *
 *     public static UserId generate() {
 *         return new UserId(UUID.randomUUID());
 *     }
 * }
 * }</pre>
 */
public interface Identity extends ValueObject {

    UUID key();

    /**
     * Guards an identity key: it can't be {@code null} or the empty (nil) UUID.
     *
     * @return the key, so it can be used inline
     */
    static UUID requireValid(UUID key) {
        if (key == null || key.equals(new UUID(0L, 0L))) {
            throw new IllegalArgumentException("Key can't be empty");
        }
        return key;
    }
}
