package ddd.domain.core;

/**
 * Base class for violations of a domain rule. Create one subclass per rule, named in the ubiquitous
 * language (e.g. {@code UserAlreadyDeactivated}), so the rule is visible in the model and in tests.
 *
 * <p>Unchecked on purpose: a broken domain rule is not something every caller should be forced to
 * catch, and checked exceptions would leak through every method signature of the model.
 */
public abstract class DomainRuleViolation extends RuntimeException {

    protected DomainRuleViolation(String message) {
        super(message);
    }
}
