namespace Lapka.Pet.Core.Exceptions;

internal class VolunteerAlreadyExistsException : DomainException
{
    internal VolunteerAlreadyExistsException() : base("Volunteer already exists")
    {
    }
}