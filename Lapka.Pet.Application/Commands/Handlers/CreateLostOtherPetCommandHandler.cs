using Convey.CQRS.Commands;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateLostOtherPetCommandHandler : ICommandHandler<CreateLostOtherPetCommand>
{
    private readonly ILostPetRepository _repository;

    public CreateLostOtherPetCommandHandler(ILostPetRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(CreateLostOtherPetCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var other = new LostOther(command.OwnerId, command.ProfilePhotoId, command.Name, command.Gender,
            command.DateOfBirth, command.IsSterilized, command.Weight, command.DateOfDisappearance, command.PhoneNumber,
            command.Longitude, command.Latitude, command.IsVisible, command.FirstName, command.Description);

        await _repository.AddAsync(other);
    }
}