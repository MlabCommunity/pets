
using Lapka.Pet.Core.Kernel.Abstractions;

namespace Lapka.Pet.Core.Events;


public record ShelterUpdatedEvent(Guid Id, string OrganizationName, double Longitude, double Latitude,string City,string Street,string ZipCode,
    string Krs, string Nip) : IDomainEvent;