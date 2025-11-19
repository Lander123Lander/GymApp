using GymApp_shared.DTOs;

namespace GymApp_frontend.Services;

public class AuthService : BaseService
{
    public AuthService() : base()
    {
    }

    public Task<LoginResponse> LoginAsync(string username, string password)
    {
        var loginRequest = new { EmailOrUsername = username, Password = password };
        return PostAsync<LoginResponse>("api/login", loginRequest);
    }
}