using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Core.ValueObjects;

public record VisitType
{
    public CareType Type { get; }
    public Visit Visit { get; }
    public EntityId VisitId { get; }
    
    public VisitType()
    {
    }

    public VisitType(CareType type,Visit visit)
    {
        Visit = visit;
        VisitId = visit.VisitId;
        Type = type;
    }
}