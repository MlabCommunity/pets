namespace Lapka.Pet.Core.Exceptions;

public class VolunteerNotFoundException : DomainException
{
    public VolunteerNotFoundException() : base("Volunteer not found")
    {
    }
    
}