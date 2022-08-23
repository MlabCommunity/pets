using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class DeleteCardCommandHandler : ICommandHandler<DeleteCardCommand>
{
    private readonly IPetRepository _petRepository;
    
    public DeleteCardCommandHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }
    
    public async Task HandleAsync(DeleteCardCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var pet = await _petRepository.FindByIdAsync(command.PetId);

        if (pet is null)
        {
            throw new PetNotFoundException();
        }
        
        if(pet.OwnerId != command.PrincipalId)
        {
            throw new PetNotFoundException(); //TODO:FORBIDDEN?
        }

        await _petRepository.RemoveAsync(pet);
    }
}