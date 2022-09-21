﻿using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Exceptions;

namespace Lapka.Pet.Core.ValueObjects;

public record ProfilePhoto 
{
    public string? Value { get; }
    
    public ProfilePhoto(string? value)
    {
        if (Uri.IsWellFormedUriString(value, UriKind.Relative))
        {
            throw new InvalidUrlException();
        }
        Value = value;
    }
    
    public static implicit operator ProfilePhoto(string link)
        => new(link);

    public static implicit operator string(ProfilePhoto? link)
        => link?.Value;
}