using Convey.CQRS.Commands;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateCatCommandHandler : ICommandHandler<CreateCatCommand>
{
    private readonly IPetRepository _petRepository;

    public CreateCatCommandHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task HandleAsync(CreateCatCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var cat = Cat.Create(command.OwnerId, command.ProfilePhoto, command.Name, command.Gender, command.DateOfBirth,
            command.IsSterilized,
            command.Weight, command.CatBreed, command.CatColor, command.Photos);

        await _petRepository.AddPetAsync(cat);
    }
}