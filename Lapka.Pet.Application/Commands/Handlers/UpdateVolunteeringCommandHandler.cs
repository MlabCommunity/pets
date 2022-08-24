using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class UpdateVolunteeringCommandHandler : ICommandHandler<UpdateVolunteeringCommand>
{
    private readonly IShelterRepository _shelterRepository;

    public UpdateVolunteeringCommandHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }

    public async Task HandleAsync(UpdateVolunteeringCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByIdAsync(command.UserId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        shelter.ConfigureVolunteering(new Volunteering(command.IsDonationActive, command.BankAccountNumber,
            command.DonationDescription, command.IsDailyHelpActive, command.DailyHelpDescription,
            command.IsTakingDogsOutActive, command.TakingDogsOutDescription));

        await _shelterRepository.UpdateAsync(shelter);
    }
}