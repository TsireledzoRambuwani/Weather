using AspNetCoreRateLimit;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using WeatherApi.Helpers;
using WeatherApi.Middleware;
using WeatherApi.Models.Validators;
using WeatherApi.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});



builder.Services.AddMemoryCache();

builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimitPolicies"));
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IWeatherRepository, WeatherRepository>();

builder.Services.AddInMemoryRateLimiting();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("WeatherApi", httpClient =>
{
    var uri = builder.Configuration.GetValue<string>("API:WeatherApi");

    httpClient.BaseAddress = new Uri(uri);
    httpClient.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddSingleton<IHTTPClientHelperRepository, HTTPClientHelperRepository>(s =>
             new HTTPClientHelperRepository(s.GetService<IHttpClientFactory>(), "WeatherApi")
             );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseIpRateLimiting();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
