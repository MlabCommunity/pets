using System.Text.RegularExpressions;
using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public record PhoneNumber
{
    public string Value { get; }

    public PhoneNumber(string value)
    {
        if (!Regex.IsMatch(value, @"^\d{9,10}$"))
        {
            throw new InvalidPhoneNumberException();
        }

        Value = value;
    }

    public static implicit operator string(PhoneNumber number)
        => number.Value;

    public static implicit operator PhoneNumber(string number)
        => new(number);
}