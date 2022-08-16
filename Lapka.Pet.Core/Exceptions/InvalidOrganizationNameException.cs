namespace Lapka.Pet.Core.Exceptions;

public class InvalidOrganizationNameException : DomainException
{
    public InvalidOrganizationNameException() : base("Invalid organization name, max lenght is 100 characters")
    {
    }
}