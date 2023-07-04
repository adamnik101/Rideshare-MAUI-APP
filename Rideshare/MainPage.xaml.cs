using Rideshare.Pages.Auth;

namespace Rideshare;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
	}

    private async void LoginPage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

    private async void RegisterPage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }
}

