namespace GymApp_frontend.Pages;

public partial class WelcomePage : ContentPage
{
    public WelcomePage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Login");
    }

    private async void OnCreateAccountClicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new RegisterPage());
    }
}
