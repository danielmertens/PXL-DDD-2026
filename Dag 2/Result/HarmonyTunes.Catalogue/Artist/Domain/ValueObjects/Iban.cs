using System.Text.RegularExpressions;

namespace HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;

public record Iban
{
    public string Value { get; }

    public Iban(string value)
    {
        if (string.IsNullOrEmpty(value)) { throw new ArgumentException(nameof(value)); }

        // Store one notation, so "be68 5390 0754 7034" equals "BE68539007547034".
        var iban = value.Replace(" ", "").ToUpperInvariant();

        // Country (2 letters), check digits (2) and the account number of that country.
        if (!Regex.IsMatch(iban, @"^[A-Z]{2}[0-9]{2}[A-Z0-9]{11,30}\z")) { throw new ArgumentException(nameof(value)); }
        if (!HasValidCheckDigits(iban)) { throw new ArgumentException(nameof(value)); }

        Value = iban;
    }

    // Move the first four characters to the end and read each letter as a number (A = 10 ... Z = 35).
    // The number you get must leave 1 when divided by 97.
    private static bool HasValidCheckDigits(string iban)
    {
        var remainder = 0;
        foreach (var character in iban[4..] + iban[..4])
        {
            var number = char.IsDigit(character) ? character - '0' : character - 'A' + 10;
            remainder = (remainder * (number < 10 ? 10 : 100) + number) % 97;
        }

        return remainder == 1;
    }
}
