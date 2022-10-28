namespace Lapka.Pet.Api.Requests.Validations;

internal static class RegexRules
{
    public const string PhoneNumberRule = @"^\d{9,10}$";
    public const string NipKrsRule = @"^\d{10}$";
    public const string BankAccountRule = @"^\d$";
    public const string ZipCodeRule = @"^\d\d-\d\d\d$";
}