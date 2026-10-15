using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Shared.Domain;

public class Url : ValueObject
{
    public string Value { get; }
    public Url(string value)
    {
        if (string.IsNullOrEmpty(value)) { throw new ArgumentException(nameof(value)); }
        // Add more checks to verify this is a valid URL
        Value = value;
    }

    protected override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
