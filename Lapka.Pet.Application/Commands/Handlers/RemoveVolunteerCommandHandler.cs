using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class RemoveVolunteerCommandHandler : ICommandHandler<RemoveVolunteerCommand>
{
    private readonly IShelterRepository _shelterRepository;
    
    public RemoveVolunteerCommandHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }
    
    public async Task HandleAsync(RemoveVolunteerCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByShelterId(command.ShelterId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }
        
        shelter.RemoveVolunteer(command.PrincipalId);

        await _shelterRepository.UpdateAsync(shelter);
    }
}