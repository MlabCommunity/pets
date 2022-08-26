using System.Text.RegularExpressions;
using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public record ZipCode
{
    public string Value { get; }

    public ZipCode(string value)
    {
        if (!Regex.IsMatch(value, @"^\d\d-\d\d\d$"))
        {
            throw new InvalidZipCodeException();
        }

        Value = value;
    }

    public static implicit operator string(ZipCode zipCode)
        => zipCode.Value;

    public static implicit operator ZipCode(string zipCode)
        => new(zipCode);
}