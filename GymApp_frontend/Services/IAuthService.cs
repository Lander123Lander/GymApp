using GymApp_shared.DTOs;
using Refit;

namespace GymApp_frontend.Services;

public interface IAuthService
{
    [Post("/Auth/login")]
    Task<LoginResponse> Login([Body] LoginRequest loginRequest);

    [Post("/Auth/refresh")]
    Task<LoginResponse> Refresh([Body] string refreshToken);
}