namespace Lapka.Pet.Core.ValueObjects;

public record Volunteering
{
    public bool IsDonationActive { get; }
    public string BankAccountNumber { get; }
    public string DonationDescription { get; }
    public bool IsDailyHelpActive { get; }
    public string DailyHelpDescription { get; }
    public bool IsTakingDogsOutActive { get; }
    public string TakingDogsOutDescription { get; }

    public Volunteering()
    {
        IsDonationActive = false;
        IsDailyHelpActive = false;
        IsTakingDogsOutActive = false;
        TakingDogsOutDescription = "";
        BankAccountNumber = ""; //TODO ADD VALIDATION
        DonationDescription = "";
        DailyHelpDescription = "";
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