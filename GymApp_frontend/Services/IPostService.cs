using GymApp_shared.DTOs;
using Refit;

namespace GymApp_frontend.Services;

public interface IPostService
{
    [Get("/Test")]
    Task<HttpResponseMessage> Test();
}