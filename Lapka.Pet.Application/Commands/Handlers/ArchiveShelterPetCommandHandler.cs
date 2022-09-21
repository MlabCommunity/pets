﻿using Convey.CQRS.Commands;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Repositories;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class ArchiveShelterPetCommandHandler : ICommandHandler<ArchiveShelterPetCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IUserCacheStorage _cacheStorage;

    public ArchiveShelterPetCommandHandler(IShelterRepository shelterRepository, IUserCacheStorage cacheStorage)
    {
        _shelterRepository = shelterRepository;
        _cacheStorage = cacheStorage;
    }

    public async Task HandleAsync(ArchiveShelterPetCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var shelterId = _cacheStorage.GetShelterId(command.PrincipalId);

        var shelter =await _shelterRepository.FindByIdAsync(shelterId);

        if (shelter is null)
        {
            throw new ShelterNotFoundException();
        }
        
        shelter.ArchivePet(command.PetId);

        await _shelterRepository.UpdateAsync(shelter);
    }
}