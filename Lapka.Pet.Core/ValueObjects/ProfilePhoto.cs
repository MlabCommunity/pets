using Lapka.Pet.Core.DomainThings;

namespace Lapka.Pet.Core.ValueObjects;

public class ProfilePhoto 
{
    public string Value { get; }
    
    public ProfilePhoto(string value)
    {
        Value = value;
    }

    public static implicit operator ProfilePhoto(string link)
        => new(link);
    
    public static implicit operator string(ProfilePhoto link)
        => link.Value;
}