using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Core.ValueObjects;

public class WorkerId : TypeId
{
    
    public WorkerId(Guid value) : base(value)
    {
    }

    public static implicit operator WorkerId(Guid id) => new(id);
}