using System.Text.RegularExpressions;

namespace HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;

public record Bic
{
    public string Value { get; }

    public Bic(string value)
    {
        if (string.IsNullOrEmpty(value)) { throw new ArgumentException(nameof(value)); }

        // Store one notation, so "gebabebb" equals "GEBABEBB".
        var bic = value.Replace(" ", "").ToUpperInvariant();

        // Bank (4 letters), country (2 letters), location (2) and optionally a branch (3).
        if (!Regex.IsMatch(bic, @"^[A-Z]{6}[A-Z0-9]{2}([A-Z0-9]{3})?\z")) { throw new ArgumentException(nameof(value)); }

        Value = bic;
    }
}
