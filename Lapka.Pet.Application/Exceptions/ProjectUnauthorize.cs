using System.Diagnostics;
using System.Runtime.Serialization;

namespace Lapka.Pet.Application.Exceptions;

public class ProjectUnauthorized : Exception
{
    public ProjectUnauthorized() : base()
    {
    }
}