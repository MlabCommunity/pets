using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record UpdateVolunteeringCommand(Guid ShelterId, string BankAccountNumber, string DonationDescription,
    string DailyHelpDescription, string TakingDogsOutDescription, bool IsDonationActive, bool IsDailyHelpActive,
    bool IsTakingDogsOutActive) : ICommand;