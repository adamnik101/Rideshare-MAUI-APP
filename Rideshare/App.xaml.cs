using Rideshare.Business;
using Rideshare.Pages;
using Rideshare.Pages.Auth;

namespace Rideshare;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainPage());
	}
}
