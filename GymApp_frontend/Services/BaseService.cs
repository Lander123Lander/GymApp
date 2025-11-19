using System.Net;
using System.Text;
using System.Text.Json;

namespace GymApp_frontend.Services;

public abstract class BaseService
{
    protected readonly HttpClient _httpClient;

    protected BaseService()
    {
        _httpClient = new HttpClient();
    }

    protected async Task<T> PostAsync<T>(string url, object data)
    {
        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, content);

        await EnsureSuccessOrThrowAsync(response);

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }

    protected async Task EnsureSuccessOrThrowAsync(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
            return;

        var error = await response.Content.ReadAsStringAsync();

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            throw new UnauthorizedAccessException(error);

        throw new HttpRequestException($"Request failed with status {response.StatusCode}: {error}");
    }
}
