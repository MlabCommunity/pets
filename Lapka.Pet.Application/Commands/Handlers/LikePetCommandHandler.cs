using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class LikePetCommandHandler : ICommandHandler<LikePetCommand>
{
    private readonly IPetRepository _petRepository;

    public LikePetCommandHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task HandleAsync(LikePetCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var pet = await _petRepository.FindByIdAsync(command.PetId);

        if (pet is null)
        {
            throw new PetNotFoundException();
        }

        pet.Like(command.PrincipalId);

        await _petRepository.UpdateAsync(pet);
    }
}