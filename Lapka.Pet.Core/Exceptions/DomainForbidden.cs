namespace Lapka.Pet.Core.Exceptions;

public class DomainForbidden : Exception
{
    public DomainForbidden() : base("Forbidden")
    {
    }
}