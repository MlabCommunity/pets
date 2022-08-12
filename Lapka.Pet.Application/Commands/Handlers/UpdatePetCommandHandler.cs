using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class UpdatePetCommandHandler : ICommandHandler<UpdatePetCommand>
{
    private readonly IPetRepository _petRepository;

    public UpdatePetCommandHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }


    public async Task HandleAsync(UpdatePetCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var pet = await _petRepository.FindByIdAsync(command.PetId);

        if (pet is null)
        {
            throw new PetNotFoundException();
        }

        pet.Update(command.Name, command.IsSterilized, command.Weight);
        
        await _petRepository.UpdateAsync(pet);
    }
}