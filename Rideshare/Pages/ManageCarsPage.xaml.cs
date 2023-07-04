using System.Windows.Input;

namespace Rideshare.Pages;

public partial class ManageCarsPage : ContentPage
{
	public ManageCarsPage()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
		
		
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new AddCarModalPage());
    }
}