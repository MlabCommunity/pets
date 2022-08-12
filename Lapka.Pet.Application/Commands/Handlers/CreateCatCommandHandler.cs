using Convey.CQRS.Commands;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreatePetCommandHandler : ICommandHandler<CreatePetCommand>
{
    private readonly IPetRepository _petRepository;

    public CreatePetCommandHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task HandleAsync(CreatePetCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        //check if pet exists

        switch (command.PetType)
        {

        }

        //TODO throw exception
    }


}