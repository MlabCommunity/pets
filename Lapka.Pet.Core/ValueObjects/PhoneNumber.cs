using System.Text.RegularExpressions;
using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public record PhoneNumber
{
    public string Value { get; }

    public PhoneNumber(string value)
    {
        //     if (!Regex.IsMatch(value, @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$"))
        //   {
        //       throw new InvalidPhoneNumberException();
        //   }  TODO add regex

        Value = value;
    }

    public static implicit operator string(PhoneNumber number)
        => number.Value;

    public static implicit operator PhoneNumber(string number)
        => new(number);
}