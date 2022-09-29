using Convey.CQRS.Events;
using Convey.MessageBrokers;
using Lapka.Pet.Core.DomainThings;

namespace Lapka.Pet.Core.Events;

[Message("identity")]
public record ShelterUpdatedEvent(Guid Id, string OrganizationName,double Longitude, double Latitude,
    string Krs, string Nip) : IEvent;