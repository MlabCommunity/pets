namespace Lapka.Pet.Application.Services;

public interface ICacheStorage
{
    void Set<T>(string key, T value, TimeSpan? duration = null);
    T Get<T>(string key);
}