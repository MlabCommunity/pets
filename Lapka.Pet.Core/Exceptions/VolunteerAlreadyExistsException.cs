namespace Lapka.Pet.Core.Exceptions;

public class VolunteerAlreadyExistsException : DomainException
{
    public VolunteerAlreadyExistsException() : base("Volunteer already exists")
    {
    }
}