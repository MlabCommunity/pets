using Lapka.Pet.Core.Exceptions;
using Lapka.Pet.Core.Kernel.Types;

namespace Lapka.Pet.Core.ValueObjects;

public class FirstName : TypeName
{
    public FirstName(string value) : base(value)
    {
        if (value.Length > 20)
        {
            throw new InvalidFirstNameException();
        }
    }

    public static implicit operator FirstName(string value)
        => new(value);
}