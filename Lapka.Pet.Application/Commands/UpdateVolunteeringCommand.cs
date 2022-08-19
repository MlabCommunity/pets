using Convey.CQRS.Commands;

namespace aLapka.Pet.Application.Commands;

public record UpdateVolunteeringCommand(Guid UserId, string BankAccountNumber, string DonationDescription,
    string DailyHelpDescription, string TakingDogsOutDescription, bool IsDonationActive, bool IsDailyHelpActive,
    bool IsTakingDogsOutActive) : ICommand;