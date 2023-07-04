using Rideshare.Business.DTOs;

namespace Rideshare.Components;

public partial class Ride : ContentView
{
    public static readonly BindableProperty StartCityProperty =
        BindableProperty.Create(nameof(StartCity), typeof(BaseDto), typeof(Ride), null,
            propertyChanged: OnStartCityChanged);

    public static readonly BindableProperty DestinationCityProperty =
        BindableProperty.Create(nameof(DestinationCity), typeof(BaseDto), typeof(Ride), null,
            propertyChanged: OnDestinationCityChanged);

    public static readonly BindableProperty RestrictionsProperty =
       BindableProperty.Create(nameof(Restrictions), typeof(List<RestrictionDto>), typeof(Ride), null);

    public static readonly BindableProperty DriverProperty =
       BindableProperty.Create(nameof(DriverDto), typeof(DriverDto), typeof(Ride), null,
           propertyChanged: OnDriverChanged);

    public static readonly BindableProperty PriceProperty =
        BindableProperty.Create(nameof(Price), typeof(decimal), typeof(Ride), default(decimal));

    public static readonly BindableProperty StartCityNameProperty =
        BindableProperty.Create(nameof(StartCityName), typeof(string), typeof(Ride), default(string));

    public static readonly BindableProperty DestinationCityNameProperty =
        BindableProperty.Create(nameof(DestinationCityName), typeof(string), typeof(Ride), default(string)); 
    public static readonly BindableProperty DriverNameProperty =
        BindableProperty.Create(nameof(DriverName), typeof(string), typeof(Ride), default(string)); 

    public static readonly BindableProperty NumberOfAvailableSeatsProperty =
        BindableProperty.Create(nameof(NumberOfAvailableSeats), typeof(int), typeof(Ride), default(int));
    public decimal Price
    {
        get => (decimal)GetValue(PriceProperty);
        set => SetValue(PriceProperty, value);
    }
    public List<RestrictionDto> Restrictions
    {
        get => (List<RestrictionDto>)GetValue(RestrictionsProperty);
        set => SetValue(RestrictionsProperty, value);
    }
    public string DriverName
    {
        get => (string)GetValue(DriverNameProperty);
        set => SetValue(DriverNameProperty, value);
    }
    public int NumberOfAvailableSeats
    {
        get => (int)GetValue(NumberOfAvailableSeatsProperty);
        set => SetValue(NumberOfAvailableSeatsProperty, value);
    }
    public BaseDto StartCity
    {
        get => (BaseDto)GetValue(StartCityProperty);
        set => SetValue(StartCityProperty, value);
    }

    public BaseDto DestinationCity
    {
        get => (BaseDto)GetValue(DestinationCityProperty);
        set => SetValue(DestinationCityProperty, value);
    }
    public DriverDto Driver
    {
        get => (DriverDto)GetValue(DriverProperty);
        set => SetValue(DriverProperty, value);
    }
    public string StartCityName
    {
        get => (string)GetValue(StartCityNameProperty);
        set => SetValue(StartCityNameProperty, value);
    }

    public string DestinationCityName
    {
        get => (string)GetValue(DestinationCityNameProperty);
        set => SetValue(DestinationCityNameProperty, value);
    }

    private static void OnStartCityChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var rideView = (Ride)bindable;
        var startCity = (BaseDto)newValue;
        rideView.StartCityName = startCity?.Name ?? string.Empty;
    }

    private static void OnDestinationCityChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var rideView = (Ride)bindable;
        var destinationCity = (BaseDto)newValue;
        rideView.DestinationCityName = destinationCity?.Name ?? string.Empty;
    }
    private static void OnDriverChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var rideView = (Ride)bindable;
        var driver = (DriverDto)newValue;
        rideView.DriverName = driver?.FirstName ?? string.Empty;
    }
    public Ride()
	{
		InitializeComponent();
	}
}