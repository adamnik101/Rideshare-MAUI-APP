using Rideshare.Business.DTOs;

namespace Rideshare.Pages;

public partial class DetailsPage : ContentPage
{
	public DetailsPage()
	{
		InitializeComponent();
	}
    public DetailsPage(RideDto ride)
    {
        InitializeComponent();
        var ride1 = ride;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}