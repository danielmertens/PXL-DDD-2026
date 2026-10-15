namespace HarmonyTunes.Ports.Catalogue.Models;

public class BillingInfoDto
{
    public required string BankAccount { get; set; }
    public required string Bank { get; set; }
    public decimal RatePerListen { get; set; }
}
