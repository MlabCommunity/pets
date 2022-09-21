using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public record PhotoLink
{
    public string Value { get; }

    public PhotoLink(string value)
    {
        if (Uri.IsWellFormedUriString(value, UriKind.Relative))
        {
            
            throw new InvalidUrlException();
            
        }
        Value = value;
    }
    
    private PhotoLink(){}
    
    public static implicit operator PhotoLink(string link)
        => new(link);

    public static implicit operator string(PhotoLink link)
        => link.Value;
}