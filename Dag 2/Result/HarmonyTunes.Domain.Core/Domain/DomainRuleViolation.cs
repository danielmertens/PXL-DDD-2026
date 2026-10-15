namespace HarmonyTunes.Domain.Core.Domain;

public abstract class DomainRuleViolation : Exception
{
    public DomainRuleViolation(string message)
        : base(message) { }
}
