using Convey.CQRS.Commands;
using Convey.MessageBrokers;
using Convey.MessageBrokers.CQRS;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.IntegrationEvents;
using Lapka.Pet.Application.Services;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Commands.Handlers;

internal sealed class CreateShelterCommandHandler : ICommandHandler<CreateShelterCommand>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IEventProcessor _eventProcessor;

    public CreateShelterCommandHandler(IShelterRepository shelterRepository, IEventProcessor eventProcessor)
    {
        _shelterRepository = shelterRepository;
        _eventProcessor = eventProcessor;
    }

    public async Task HandleAsync(CreateShelterCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var krsExists = await _shelterRepository.KrsExistAsync(command.Krs);

        if (krsExists)
        {
            throw new KrsIsAlreadyTakenException();
        }
        
        var nipExists = await _shelterRepository.NipExistAsync(command.Nip);

        if (nipExists)
        {
            throw new NipIsAlreadyTakenException();
        }
        
        var shelter = Shelter.Create(command.UserId, command.Email, command.FirstName, command.LastName,
            command.PhoneNumber, command.Longitude, command.Latitude, command.Street, command.City, command.ZipCode,
            command.OrganizationName,
            command.Krs, command.Nip);

        await _shelterRepository.AddAsync(shelter);

        await _eventProcessor.ProcessAsync(shelter.Events);
    }
}