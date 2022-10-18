namespace Lapka.Pet.Core.Exceptions;

internal class InvalidBankAccountException : DomainException
{
    public InvalidBankAccountException() : base("Invalid bank account number")
    {
    }
}