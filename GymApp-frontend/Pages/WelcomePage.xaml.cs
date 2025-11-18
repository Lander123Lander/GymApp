namespace GymApp_frontend.Pages;

public partial class WelcomePage : ContentPage
{
    public WelcomePage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

    private async void OnCreateAccountClicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new RegisterPage());
    }
}
