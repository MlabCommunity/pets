using Lapka.Pet.Core.DomainThings;

namespace Lapka.Pet.Core.Events;

public record ShelterUpdatedEvent(Guid Id, string OrganizationName,double Longitude, double Latitude,
    string Krs, string Nip) : IDomainEvent;