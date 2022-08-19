namespace Lapka.Pet.Api.Requests;

public record CreateUserAdvertisementRequest(string Description, bool IsVisible, DateTime DateOfDisappearance,
    string CityOfDisappearance, string StreetOfDisappearance);