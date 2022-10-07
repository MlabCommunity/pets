using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Infrastructure.Mapper.Extensions;

public static class LocalizationExtension
{
    public static int CalculateDistance(this Localization localization, Longitude longitude, Latitude latitude)
    {
        if ((localization.Latitude == latitude) && (localization.Longitude == longitude))
        {
            return 0;
        }
        else
        {
            double theta = localization.Longitude - longitude;
            double dist = Math.Sin(deg2rad(localization.Latitude)) * Math.Sin(deg2rad(latitude)) +
                          Math.Cos(deg2rad(localization.Latitude)) * Math.Cos(deg2rad(latitude)) *
                          Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515 * 1.609344;

            return (int)dist;
        }
    }

    private static double deg2rad(double deg)
    {
        return (deg * Math.PI / 180.0);
    }

    private static double rad2deg(double rad)
    {
        return (rad / Math.PI * 180.0);
    }
}