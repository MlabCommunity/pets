namespace Lapka.Pet.Core.Exceptions;

public class InvalidDateOfDisappearanceException : DomainException
{
    public InvalidDateOfDisappearanceException() : base("Invalid date of disappearance")
    {
    }
    
}