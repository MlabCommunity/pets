using Convey.CQRS.Commands;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateLostDogCommandHandler : ICommandHandler<CreateLostDogCommand>
{
    private readonly ILostPetRepository _repository;

    public CreateLostDogCommandHandler(ILostPetRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(CreateLostDogCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var dog = new LostDog(command.OwnerId, command.ProfilePhoto, command.Name, command.Gender,
            command.DateOfBirth, command.IsSterilized, command.Weight, command.DateOfDisappearance, command.PhoneNumber,
            command.Longitude, command.Latitude, command.IsVisible, command.FirstName, command.Description,
            command.DogBreed, command.DogColor, command.Photos);

        await _repository.AddAsync(dog);
    }
}