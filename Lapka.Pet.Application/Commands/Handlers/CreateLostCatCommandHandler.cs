using Convey.CQRS.Commands;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateLostCatCommandHandler : ICommandHandler<CreateLostCatCommand>
{
    private readonly ILostPetRepository _repository;

    public CreateLostCatCommandHandler(ILostPetRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(CreateLostCatCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var cat = new LostCat(command.OwnerId, command.ProfilePhoto, command.Name, command.Gender,
            command.DateOfBirth, command.IsSterilized, command.Weight, command.DateOfDisappearance, command.PhoneNumber,
            command.Longitude, command.Latitude, command.IsVisible, command.FirstName, command.Description,
            command.CatBreed, command.CatColor, command.Photos);

        await _repository.AddAsync(cat);
    }
}