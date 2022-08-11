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

        if (command.PetType == PetType.CAT)
        {
            if (Enum.IsDefined(typeof(CatBreed), command.Breed) && Enum.IsDefined(typeof(CatColor), command.Color))
            {
                var cat = Cat.Create(command.OwnerId, command.Name, command.Gender, command.DateOfBirth,
                    command.IsSterilized, command.Weight, (CatBreed)command.Breed, (CatColor)command.Color);

                await _petRepository.AddPetAsync(cat);
                Console.WriteLine("Cat created");
            }
            //TODO else throw exception
        }
        
        //TODO throw exception
    }
}