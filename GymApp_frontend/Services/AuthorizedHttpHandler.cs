using System.Net;
using System.Net.Http.Headers;
using GymApp_frontend.Services;

public class AuthorizedHttpHandler : DelegatingHandler
{
    private readonly IAuthService _authService;

    public AuthorizedHttpHandler(IAuthService authService)
    {
        _authService = authService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var accessToken = await SecureStorage.GetAsync("access_token");

        // Add Bearer token
        if (!string.IsNullOrEmpty(accessToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        var response = await base.SendAsync(request, cancellationToken);

        // Refresh if unauthorized
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            var refreshToken = await SecureStorage.GetAsync("refresh_token");

            if (string.IsNullOrEmpty(refreshToken))
                return response;

            var newTokens = await _authService.Refresh(refreshToken);

            if (newTokens == null || string.IsNullOrEmpty(newTokens.AccessToken))
                return response;

            // Save new tokens
            await SecureStorage.SetAsync("access_token", newTokens.AccessToken);
            await SecureStorage.SetAsync("refresh_token", newTokens.RefreshToken);

            // Retry the original request
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", newTokens.AccessToken);
            return await base.SendAsync(request, cancellationToken);
        }

        return response;
    }
}
