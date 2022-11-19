using System;

namespace SecureWeb.Services.Values;

public class ValuesService : IValuesService
{
    private readonly HttpClient _client;
    private readonly IConfiguration _configuration;

    public ValuesService(HttpClient client,
                         IConfiguration configuration)
    {
        var baseAddress = configuration["Services:Values:BaseAddress"];
        client.BaseAddress = new Uri(baseAddress);
        _client = client;
        _configuration = configuration;
    }

    public async Task<ValuesGetDto> Get()
    {
        var response = await _client.GetAsync("api/values");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsAsync<ValuesGetDto>();
        return result;
    }
}
