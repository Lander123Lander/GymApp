using GymApp_frontend.Services;

namespace GymApp_frontend.Pages;

public partial class FeedPage : ContentPage
{
    private readonly IPostService _postService;

    public string JsonResult { get; set; } = "Loading...";

    public FeedPage(IPostService postService)
    {
        InitializeComponent();
        _postService = postService;
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            HttpResponseMessage response = await _postService.Test();
            JsonResult = await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            JsonResult = $"Error: {ex.Message}";
        }

        OnPropertyChanged(nameof(JsonResult));
    }
}
