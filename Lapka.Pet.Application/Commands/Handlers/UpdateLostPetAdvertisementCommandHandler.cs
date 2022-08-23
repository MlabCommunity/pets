using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands;

internal sealed class UpdateLostPetAdvertisementCommandHandler : ICommandHandler<UpdateLostPetAdvertisementCommand>
{
    private readonly ILostPetAdvertisementRepository _lostPetAdvertisementRepository;
    private readonly IPetRepository _petRepository;
    
    public UpdateLostPetAdvertisementCommandHandler(ILostPetAdvertisementRepository lostPetAdvertisementRepository, IPetRepository petRepository)
    {
        _lostPetAdvertisementRepository = lostPetAdvertisementRepository;
        _petRepository = petRepository;
    }
    
    public async Task HandleAsync(UpdateLostPetAdvertisementCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var advertisement = await _lostPetAdvertisementRepository.FindByPetIdAsync(command.PetId);
        
        if (advertisement is null || advertisement.UserId!=command.PrincipalId)
        {
            throw new AdvertisementNotFoundException();
        }

        var pet = await _petRepository.FindByIdAsync(command.PetId);
        
        if (pet is null)
        {
            throw new PetNotFoundException();
        }
        
        pet.Update(command.Name,command.IsSterilized,command.Weight);
        advertisement.Update(command.Description);

        await _lostPetAdvertisementRepository.UpdateAsync(advertisement);
    }
}