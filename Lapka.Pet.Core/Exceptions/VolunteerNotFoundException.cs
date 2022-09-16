namespace Lapka.Pet.Core.Exceptions;

internal class VolunteerNotFoundException : DomainException
{
    internal VolunteerNotFoundException() : base("Volunteer not found")
    {
    }
}