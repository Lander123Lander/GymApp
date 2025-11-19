using GymApp_frontend.Services;
using GymApp_shared.DTOs;

namespace GymApp_frontend.Pages;

public partial class LoginPage : ContentPage
{
    private readonly IAuthService _authService;

    public LoginPage(IAuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var username = emailOrUsernameEntry.Text?.Trim();
        var password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            ErrorLabel.Text = "Please fill in both fields.";
            return;
        }

        var request = new LoginRequest
        {
            EmailOrUsername = username,
            Password = password,
        };

        try
        {
            var loginResponse = await _authService.Login(request);

            ErrorLabel.Text = "";

            await SecureStorage.SetAsync("access_token", loginResponse.AccessToken);
            await SecureStorage.SetAsync("refresh_token", loginResponse.RefreshToken);

            await Shell.Current.GoToAsync("//Welcome");
        }
        catch (Refit.ApiException ex)
        {
            ErrorLabel.Text = ex.Content;
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Something went wrong";
        }
    }
}
