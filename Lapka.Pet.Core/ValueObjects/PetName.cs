using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public class PetName : TypeName
{
    public PetName(string value) : base(value)
    {
        if (value.Length > 20)
        {
            throw new InvalidPetNameException();
        }
    }

    public static implicit operator PetName(string value)
        => new(value);
}