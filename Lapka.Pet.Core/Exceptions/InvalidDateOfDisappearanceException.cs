namespace Lapka.Pet.Core.Exceptions;

internal class InvalidDateOfDisappearanceException : DomainException
{
    internal InvalidDateOfDisappearanceException() : base("Invalid date of disappearance")
    {
    }
}