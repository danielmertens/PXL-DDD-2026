namespace HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;

public record StageIdentification
{
    public Name FirstName { get; }
    public Name? LastName { get; }
    public IReadOnlyList<Name> MiddleNames { get; }

    public StageIdentification(Name firstName, Name? lastName, IReadOnlyList<Name> middleNames)
    {
        ArgumentNullException.ThrowIfNull(firstName);
        ArgumentNullException.ThrowIfNull(middleNames);
        if (middleNames.Contains(null)) { throw new ArgumentException(nameof(middleNames)); }

        FirstName = firstName;
        LastName = lastName;
        MiddleNames = middleNames.ToArray();
    }

    // A record compares a list by reference, so compare the names themselves.
    public virtual bool Equals(StageIdentification? other)
    {
        return other is not null &&
               FirstName == other.FirstName &&
               LastName == other.LastName &&
               MiddleNames.SequenceEqual(other.MiddleNames);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName, string.Join(' ', MiddleNames.Select(name => name.Value)));
    }
}
