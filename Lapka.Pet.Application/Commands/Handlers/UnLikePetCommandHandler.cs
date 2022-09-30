using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

public class UnLikePetCommandHandler : ICommandHandler<UnLikePetCommand>
{
    private readonly IPetRepository _petRepository;

    public UnLikePetCommandHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task HandleAsync(UnLikePetCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var pet = await _petRepository.FindByIdAsync(command.PetId);

        if (pet is null)
        {
            throw new PetNotFoundException();
        }

        pet.UnLike(command.PrincipalId);

        await _petRepository.UpdateAsync(pet);
    }
}