using Newtonsoft.Json;
using Rideshare.Business;

namespace Rideshare.Pages;

public partial class ProfilePage : ContentPage
{
	private Actor _actor;
	public ProfilePage()
	{
		InitializeComponent();
		InitializeActor();
    }
	private async Task InitializeActor()
	{
		_actor = await SecureStorage.Default.GetActor();
		lblFullname.Text = _actor.Fullname;
	}
    private async void Button_Clicked(object sender, EventArgs e)
    {

		bool shouldLogout = await DisplayAlert("Confirm", "Do you want to log out?", "Yes", "No");

		if (shouldLogout)
		{
			Application.Current.MainPage = new NavigationPage(new MainPage());
		}

		//Application.Current.MainPage = new NavigationPage(new MainPage());
		//await SecureStorage.Default.SetAsync("actor", "");
		//Application.Current.MainPage = new MainPage();
    }
} 