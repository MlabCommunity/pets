using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.Kernel.Types;

namespace Lapka.Pet.Core.ValueObjects;

public class LastName : TypeName
{
    public LastName(string value) : base(value)
    {
        if (value.Length > 20)
        {
            throw new InvalidLastNameException();
        }
    }

    public static implicit operator LastName(string value)
        => new(value);
}