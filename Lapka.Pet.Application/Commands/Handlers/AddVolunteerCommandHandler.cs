using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class AddVolunteerCommandHandler : ICommandHandler<AddVolunteerCommand>
{
    private readonly IShelterRepository _shelterRepository;
    
    public AddVolunteerCommandHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }

    public async Task HandleAsync(AddVolunteerCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByShelterId(command.ShelterId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }
        
        shelter.AddVolunteer(new Volunteer(command.PrincipalEmail,command.PrincipalId));

        await _shelterRepository.UpdateAsync(shelter);

    }
    
    
}