
using System.Net;
using WeatherApi.Wrappers;

namespace WeatherApi.Helpers
{
    public interface IHTTPClientHelperRepository
    {
        Task<(T data, HttpStatusCode? code, string? message)> GetAsync<T>(string url);

    }
}
