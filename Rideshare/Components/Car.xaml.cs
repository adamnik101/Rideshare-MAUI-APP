using Rideshare.Business.DTOs;

namespace Rideshare.Components;

public partial class Car : ContentView
{
    public static readonly BindableProperty BrandModelProperty =
        BindableProperty.Create(nameof(BrandModel), typeof(string), typeof(Car), "");
    public static readonly BindableProperty LicencePlateProperty =
        BindableProperty.Create(nameof(LicencePlate), typeof(string), typeof(Car), "");
    public static readonly BindableProperty NumberOfSeatsProperty =
        BindableProperty.Create(nameof(NumberOfSeats), typeof(string), typeof(Car), "");

    public string BrandModel
    {
        get => (string)GetValue(BrandModelProperty);
        set => SetValue(BrandModelProperty, value);
    }
    public string LicencePlate
    {
        get => (string)GetValue(LicencePlateProperty);
        set => SetValue(LicencePlateProperty, value);
    }
    public string NumberOfSeats
    {
        get => (string)GetValue(NumberOfSeatsProperty);
        set => SetValue(NumberOfSeatsProperty, value);
    }
    public Car()
	{
		InitializeComponent();
	}
}