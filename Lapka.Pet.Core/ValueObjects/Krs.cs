using System.Text.RegularExpressions;
using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public record Krs
{
    public string Value { get;}

    public Krs(string value)
    {
        if (!Regex.IsMatch(value, @"^\d{10}$"))
        {
            throw new InvalidKrsException();
        }

        Value = value;
        
    }
    
    public static implicit operator string(Krs krs)
        => krs.Value;
        
    public static implicit operator Krs(string krs)
        => new(krs);
    
}