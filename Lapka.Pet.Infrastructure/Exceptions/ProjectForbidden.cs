using Lapka.Pet.Application.Exceptions;

namespace Lapka.Pet.Infrastructure.Exceptions;

public class ProjectForbidden : ProjectException
{
    public ProjectForbidden() : base("Forbidden", 403)
    {
    }
}