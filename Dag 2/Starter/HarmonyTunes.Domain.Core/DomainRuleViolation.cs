namespace HarmonyTunes.Domain.Core;

public abstract class DomainRuleViolation : Exception
{
    public DomainRuleViolation(string message)
        : base(message) { }
}
