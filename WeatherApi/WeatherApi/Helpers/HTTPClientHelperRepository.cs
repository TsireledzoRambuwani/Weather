
using Newtonsoft.Json;
using System.Net;
using WeatherApi.Wrappers;

namespace WeatherApi.Helpers
{
    public class HTTPClientHelperRepository: IHTTPClientHelperRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        HttpClient _client = new();
        private readonly string _clientName;

        public HTTPClientHelperRepository(IHttpClientFactory httpClientFactory, string clientName)
        {
            _httpClientFactory = httpClientFactory;
            _clientName = clientName;
        }
        public async Task<(T data, HttpStatusCode? code, string? message)> GetAsync<T>(string url)
        {
            _client = _httpClientFactory.CreateClient(_clientName);
            try
            {
                var httpresponse = await _client.GetAsync(url);

                if (!httpresponse.IsSuccessStatusCode)
                    return (default(T), httpresponse?.StatusCode,httpresponse?.ReasonPhrase ?? string.Empty);

                string responseData = await httpresponse.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<T>(responseData);

 

                return (response, null, null);


            }
            catch (Exception ex)
            {
                throw;
            }
      
        }
       
    }
}
