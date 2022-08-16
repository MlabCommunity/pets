using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Exceptions;

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