# DDD.Domain.Java

Java starter for the day 1 exercises. Same building blocks as `DDD.Domain.NET`, but set up the way you would in Java.
No libraries: the domain only uses the JDK. JUnit is only there for tests.

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

## Differences from the .NET version

- **No `ValueObject` base class.** In .NET you override `GetValues()` to get equality by value.
  A Java `record` already compares by value, so `ValueObject` is just a marker interface.
- **`Identity` is an interface, not a base class.** Records can't extend classes, so each id record calls
  `Identity.requireValid(key)` in its constructor.
- **No `dynamic` dispatch for events.** .NET calls `When(evt)` dynamically, so a missing handler only fails
  at runtime. In Java the events of an aggregate form a `sealed` interface, and `AggregateState.when`
  uses an exhaustive `switch`: a missing handler is a compile error.
- **The event type is a type parameter.** `AggregateRoot<UserId, UserEvent, UserState>` only accepts
  `UserEvent`s, so you can't raise an event of another aggregate by accident.
- **Only the aggregate can mutate the state.** `when` is `protected`, so code outside the aggregate can
  read `currentState()` but can't apply events to it.
- **The initial state is passed in.** Java can't do `new TState()` on a generic type, so the aggregate
  passes `new UserState()` to the `super` constructor.
- **`IDomainEvent` and `DomainEvent` are merged** into one `DomainEvent` interface.
- **Record-style accessors** (`id()`, `version()`, `events()`) instead of JavaBean getters.
