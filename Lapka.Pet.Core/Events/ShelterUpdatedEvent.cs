using Convey.CQRS.Events;
using Lapka.Pet.Core.DomainThings;

namespace Lapka.Pet.Core.Events;

public record ShelterUpdatedEvent(Guid Id, string OrganizationName, string Street, string City, string ZipCode,
    string Krs, string Nip) : IDomainEvent;