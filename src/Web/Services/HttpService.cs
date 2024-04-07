using Humanizer;
using System.Text.Json;

namespace Fiap.UI.Escola.Web.Services;

internal class HttpService<TEntity> where TEntity : class
{
    protected readonly HttpClient _client;
    protected readonly IConfiguration _configuration;

    private string _baseUrl => _configuration["ApiSettings:Uri"]!;

    private string _routeName => typeof(TEntity).Name.ToLower().Pluralize();

    protected HttpService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _client = httpClientFactory.CreateClient(configuration["ApiSettings:Name"]!);
        _configuration = configuration;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var message = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/{_routeName}");

        var response = await _client.SendAsync(message);
        
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<TEntity[]>(json)!;
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        var message = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/{_routeName}/{id}");

        var response = await _client.SendAsync(message);
        
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<TEntity>(json)!;
    }

    public async Task InsertAsync(TEntity entity)
    {
        var message = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/{_routeName}")
        {
            Content = new StringContent(JsonSerializer.Serialize(entity), null, "application/json")
        };

        var response = await _client.SendAsync(message);
        
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(int id, TEntity entity)
    {
        var message = new HttpRequestMessage(HttpMethod.Put, $"{_baseUrl}/{_routeName}/{id}")
        {
            Content = new StringContent(JsonSerializer.Serialize(entity), null, "application/json")
        };

        var response = await _client.SendAsync(message);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var message = new HttpRequestMessage(HttpMethod.Delete, $"{_baseUrl}/{_routeName}/{id}");

        var response = await _client.SendAsync(message);

        response.EnsureSuccessStatusCode();
    }
}
