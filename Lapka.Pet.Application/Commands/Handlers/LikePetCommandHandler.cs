using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class LikePetCommandHandler : ICommandHandler<LikePetCommand>
{
    private readonly IPetRepository _petRepository;
    private readonly IEventProcessor _eventProcessor;

    public LikePetCommandHandler(IPetRepository petRepository, IEventProcessor eventProcessor)
    {
        _petRepository = petRepository;
        _eventProcessor = eventProcessor;
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

        await _eventProcessor.ProcessAsync(pet.Events);
    }
}