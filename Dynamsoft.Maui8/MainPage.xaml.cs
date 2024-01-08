namespace Dynamsoft.Maui8;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(CameraPage),typeof(CameraPage));
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CameraPage));
    }
}
