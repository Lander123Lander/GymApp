using System.Windows.Input;

namespace GymApp_frontend.Controls;

public partial class BottomNav : ContentView
{
    public BottomNav()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public ICommand NavigateHomeCommand => new Command(() => Shell.Current.GoToAsync("//feed"));
    public ICommand NavigateSearchCommand => new Command(() => Shell.Current.GoToAsync("//create"));
    public ICommand NavigateSettingsCommand => new Command(() => Shell.Current.GoToAsync("//profile"));
}
