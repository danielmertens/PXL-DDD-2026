# DDD.Domain.Java

**Requirements:** JDK 21 or newer. Maven is optional: use the wrapper (`./mvnw` or `mvnw.cmd`).

```
mvnw.cmd verify      # Windows
./mvnw verify        # macOS / Linux
```

Or open the folder in IntelliJ IDEA / VS Code as a Maven project.

## Structure

| Module        | Contents                                                                 |
|---------------|--------------------------------------------------------------------------|
| `domain-core` | The building blocks (package `ddd.domain.core`). No dependencies.        |
| `domain`      | Your model for the exercises (package `ddd.domain`). Depends only on `domain-core`. |

The Maven modules enforce the dependency direction: `domain-core` can't see your model.

## Building blocks

| Type                  | Use it for                                                                              |
|-----------------------|-----------------------------------------------------------------------------------------|
| `ValueObject`         | Marker interface. Implement value objects as `record`s; validate in the compact constructor. |
| `Identity`            | Strongly typed id (`record UserId(UUID key) implements Identity`). `Identity.requireValid(key)` rejects `null` and the empty UUID. |
| `DomainEvent`         | Marker interface. Events are records; group an aggregate's events under a `sealed` interface. |
| `DomainRuleViolation` | Base class (unchecked) for one exception per broken domain rule.                         |
| `AggregateState<E>`   | The aggregate's state. Implement `when(E event)` with a `switch` over the sealed events.   |
| `AggregateRoot<ID, E, S>` | Base class for aggregates. Commands check the rules, then call `raiseEvent(event)`.  |

The Javadoc of each type has a short example.
