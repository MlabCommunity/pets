using Lapka.Pet.Core.Kernel.Types;

namespace Lapka.Pet.Core.ValueObjects;

public class UserId : TypeId
{
    public UserId(Guid value) : base(value)
    {
    }

    public static implicit operator UserId(Guid id) => new(id);
}