namespace Lapka.Pet.Core.Exceptions;

public class VisitNotFoundException : DomainException
{
    public VisitNotFoundException() : base("Visit not found")
    {
    }
}