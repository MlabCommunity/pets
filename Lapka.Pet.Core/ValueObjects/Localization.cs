namespace Lapka.Pet.Core.ValueObjects;

public record Localization(string City, string Street)
{
    public static Localization Create(string value)
    {
        var splitLocalization = value.Split(',');
        return new Localization(splitLocalization.First(), splitLocalization.Last());
    }

    public override string ToString()
        => $"{City},{Street}";
}