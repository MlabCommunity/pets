namespace Lapka.Pet.Api.Requests;

public record UpdateVolunteeringRequest(string BankAccountNumber, string DonationDescription,
    string DailyHelpDescription, string TakingDogsOutDescription, bool IsDonationActive, bool IsDailyHelpActive,
    bool IsTakingDogsOutActive);