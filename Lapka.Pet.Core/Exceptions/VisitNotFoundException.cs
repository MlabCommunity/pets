namespace Lapka.Pet.Core.Exceptions;

internal class VisitNotFoundException : DomainException
{
    internal VisitNotFoundException() : base("Visit not found")
    {
    }
}