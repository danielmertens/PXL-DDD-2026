namespace HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;

public record BillingInfo
{
    public Iban BankAccount { get; }
    public Bic Bank { get; }
    public Rate RatePerListen { get; }

    public BillingInfo(Iban bankAccount, Bic bank, Rate ratePerListen)
    {
        ArgumentNullException.ThrowIfNull(bankAccount);
        ArgumentNullException.ThrowIfNull(bank);
        ArgumentNullException.ThrowIfNull(ratePerListen);

        BankAccount = bankAccount;
        Bank = bank;
        RatePerListen = ratePerListen;
    }
}
