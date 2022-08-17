using System.Text.RegularExpressions;
using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public record Email
{
    public string Value { get; }

    public Email(string value)
    {
        if (!Regex.IsMatch(value, @"^\S+@\S+\.\S+$"))
        {
            throw new InvalidEmailException();
        }
        
        Value = value;
    }

    public static implicit operator string(Email name)
        => name.Value;
        
    public static implicit operator Email(string name)
        => new(name);
    
}