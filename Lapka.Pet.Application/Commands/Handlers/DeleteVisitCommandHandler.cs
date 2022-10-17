using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class DeleteVisitCommandHandler : ICommandHandler<DeleteVisitCommand>
{
    private readonly IPetRepository _petRepository;

    public DeleteVisitCommandHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task HandleAsync(DeleteVisitCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var pet = await _petRepository.FindByIdAsync(command.PetId);

        if (pet is null)
        {
            throw new PetNotFoundException();
        }

        pet.RemoveVisit(command.VisitId, command.PrincipalId);

        await _petRepository.UpdateAsync(pet);
        
    }
}