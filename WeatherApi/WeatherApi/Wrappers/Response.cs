using Newtonsoft.Json;
using System.Net;


namespace WeatherApi.Wrappers
{
    public class Response<T>
    {
        public bool? Succeeded { get; set; }
        public string? Message { get; set; }
        public HttpStatusCode? Code { get; set; }
        public List<string>? Errors { get; set; }
        public T? Data { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string? Source { get; set; }

        public Response()
        {

        }
        public Response(string message, HttpStatusCode? code = HttpStatusCode.BadRequest)
        {
            Message = message;
            Succeeded = false;
            Code = code;
        }

        public Response(T data, string? message = null)
        {
            Data = data;
            Message = message;
            Succeeded = true;
            Code = HttpStatusCode.OK;
        }
    }
}
