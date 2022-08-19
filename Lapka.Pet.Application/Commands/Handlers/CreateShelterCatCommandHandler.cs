using System.Windows.Input;
using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateShelterCatCommandHandler : ICommandHandler<CreateShelterCatCommand>
{
    private readonly IPetRepository _petRepository;
    private readonly IShelterRepository _shelterRepository;

    public CreateShelterCatCommandHandler(IPetRepository petRepository, IShelterRepository shelterRepository)
    {
        _petRepository = petRepository;
        _shelterRepository = shelterRepository;
    }

    public async Task HandleAsync(CreateShelterCatCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var shelter = await _shelterRepository.FindByIdOrWorkerIdAsync(command.PrincipalId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }

        var cat = Cat.Create(shelter.Id.Value, command.Name, command.Gender, command.DateOfBirth, command.IsSterilized,
            command.Weight, command.CatBreed, command.CatColor);

        await _petRepository.AddPetAsync(cat);
    }
}