using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateVisitCommandHandler : ICommandHandler<CreateVisitCommand>
{
    private readonly IPetRepository _petRepository;

    public CreateVisitCommandHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task HandleAsync(CreateVisitCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var pet = await _petRepository.FindByIdAsync(command.PetId);

        if (pet is null)
        {
            throw new PetNotFoundException();
        }

        pet.AddVisit(command.HasTookPlace, command.DateOfVisit, command.Description, command.CareTypes,
            command.WeightOnVisit, command.PrincipalId);

        await _petRepository.UpdateAsync(pet);
    }
}