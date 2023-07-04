using System.Windows.Input;

namespace Rideshare.Pages;

public partial class AddCarModalPage : ContentPage
{
	public AddCarModalPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }
}