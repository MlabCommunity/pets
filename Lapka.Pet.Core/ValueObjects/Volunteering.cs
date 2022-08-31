namespace Lapka.Pet.Core.ValueObjects;

public record Volunteering
{
    public bool IsDonationActive { get; init; }
    public string BankAccountNumber { get; init; }
    public string DonationDescription { get; init; }
    public bool IsDailyHelpActive { get; init; }
    public string DailyHelpDescription { get; init; }
    public bool IsTakingDogsOutActive { get; init; }
    public string TakingDogsOutDescription { get; init; }

    private Volunteering()
    {
    }

    public Volunteering(bool isDonationActive, string bankAccountNumber, string donationDescription,
        bool isDailyHelpActive, string dailyHelpDescription, bool isTakingDogsOutActive,
        string takingDogsOutDescription)
    {
        IsDonationActive = isDonationActive;
        BankAccountNumber = bankAccountNumber;
        DonationDescription = donationDescription;
        IsDailyHelpActive = isDailyHelpActive;
        DailyHelpDescription = dailyHelpDescription;
        IsTakingDogsOutActive = isTakingDogsOutActive;
        TakingDogsOutDescription = takingDogsOutDescription;
    }
}