using Lapka.Pet.Core.DomainThings;

namespace Lapka.Pet.Core.ValueObjects;

public class PhotoLink 
{
    public string Value { get; }
    public PhotoLink(string value)
    {
        Value = value;
    }

    public static implicit operator PhotoLink(string link)
        => new(link);
    
    public static implicit operator string(PhotoLink link)
        => link.Value;
}