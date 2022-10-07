using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.Kernel.Types;

namespace Lapka.Pet.Core.ValueObjects;

public class OrganizationName : TypeName
{
    public OrganizationName(string value) : base(value)
    {
        if (value.Length > 100)
        {
            throw new InvalidOrganizationNameException();
        }
    }

    public static implicit operator OrganizationName(string value)
        => new(value);
}