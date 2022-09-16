namespace Lapka.Pet.Core.Exceptions;

internal class InvalidOrganizationNameException : DomainException
{
    internal InvalidOrganizationNameException() : base("Invalid organization name, max lenght is 100 characters")
    {
    }
}