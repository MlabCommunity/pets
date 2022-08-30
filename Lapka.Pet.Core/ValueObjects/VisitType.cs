using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Core.ValueObjects;

public record VisitType
{
    public CareType Type { get; }

    public VisitType()
    {
    }

    public VisitType(CareType type)
    {
        Type = type;
    }
}