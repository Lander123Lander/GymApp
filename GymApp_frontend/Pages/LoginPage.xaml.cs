using GymApp_frontend.Pages;

namespace GymApp_frontend.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
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

        if (username == "test" && password == "1234")
        {
            ErrorLabel.IsVisible = false;
            await Shell.Current.GoToAsync("//main");
        }
        else
        {
            ErrorLabel.Text = "Invalid username or password.";
            ErrorLabel.IsVisible = true;
        }
    }
}
