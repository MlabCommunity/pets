using Convey.CQRS.Events;

namespace Lapka.Pet.Application.IntegrationEvents;

public record UserUpdatedEvent(Guid UserId, string Role, string FirstName, string LastName, string ProfilePictureId,
    string Email) : IEvent;