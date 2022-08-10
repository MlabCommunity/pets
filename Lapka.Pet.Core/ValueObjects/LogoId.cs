namespace Lapka.Pet.Core.ValueObjects;

public class LogoId : TypeId
{
    public LogoId(Guid value) : base(value)
    {
    }
    
    public static implicit operator LogoId(Guid id)
        => new(id);
}