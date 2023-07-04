using Rideshare.Business;
using Rideshare.Pages;

namespace Rideshare;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainPage());
	}
}
