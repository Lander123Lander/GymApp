using GymApp_frontend.Services;

namespace GymApp_frontend.Pages;

public partial class LoginPage : ContentPage
{
    private readonly AuthService _authService;

    public LoginPage()
    {
        InitializeComponent();
        _authService = new AuthService();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var username = emailOrUsernameEntry.Text?.Trim();
        var password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            ErrorLabel.Text = "Please fill in both fields.";
            ErrorLabel.IsVisible = true;
            return;
        }

        try
        {
            var loginResponse = await _authService.LoginAsync(username, password);

            ErrorLabel.IsVisible = false;

            // TODO: Save tokens securely (SecureStorage or similar)
            // Example:
            // await SecureStorage.SetAsync("access_token", loginResponse.AccessToken);
            // await SecureStorage.SetAsync("refresh_token", loginResponse.RefreshToken);

            System.Diagnostics.Debug.WriteLine($"AccessToken: {loginResponse.AccessToken}");
            System.Diagnostics.Debug.WriteLine($"RefreshToken: {loginResponse.RefreshToken}");

            await Shell.Current.GoToAsync("//main");
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Invalid username or password.";
            ErrorLabel.IsVisible = true;
        }
    }
}
