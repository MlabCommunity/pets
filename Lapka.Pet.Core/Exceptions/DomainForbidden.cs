using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Infrastructure.Exceptions;

public class DomainForbidden : Exception
{
    public DomainForbidden() : base("Forbidden")
    {
    }
}