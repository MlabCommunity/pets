using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public record Photo
{
    public string Value { get; }

    private Photo(string value)
    {
        if (!Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute))
        {
            throw new InvalidUrlException();
        }
        Value = value;
    }
    
    private Photo(){}

    public static implicit operator Photo(string link)
        => new(link);

    public static implicit operator string(Photo? link)
        => link?.Value;
}
