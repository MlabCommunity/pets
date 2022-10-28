using System.Text.RegularExpressions;
using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public record Nip
{
    public string Value { get; }

    public Nip(string value)
    {
        if (!Regex.IsMatch(value, @"^\d{10}$"))
        {
            throw new InvalidNipException();
        }

        Value = value;
    }

    public static implicit operator string(Nip nip)
        => nip.Value;

    public static implicit operator Nip(string nip)
        => new(nip);
}