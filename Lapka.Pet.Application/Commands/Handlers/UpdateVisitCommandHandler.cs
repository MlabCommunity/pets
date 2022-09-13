using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class UpdateVisitCommandHandler : ICommandHandler<UpdateVisitCommand>
{
    private readonly IPetRepository _petRepository;

    public UpdateVisitCommandHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task HandleAsync(UpdateVisitCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var pet = await _petRepository.FindByIdAsync(command.PetId);

        if (pet is null)
        {
            throw new PetNotFoundException();
        }

        pet.UpdateVisit(command.VisitId, command.PrincipalId, command.HasTookPlace, command.DateOfVisit,
            command.Description, command.VisitTypes, command.WeightOnVisit);

        await _petRepository.UpdateAsync(pet);
    }
}