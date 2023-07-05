using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using FluentValidation.Results;
using Rideshare.Business.DTOs;
using Rideshare.Business.Services;
using Rideshare.Common;
using Rideshare.Pages.Auth;
using Rideshare.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rideshare.ViewModels
{
    public class MRegisterViewModel : BaseViewModel
    {
        private GenderService _genderService;
        private AuthService _authService;
        public MRegisterViewModel()
        {
            _authService = new AuthService();
            _genderService = new GenderService();
            RegisterCommand = new Command(Register);
            GetGenders();
        }

        private void Register(object obj)
        {
            ValidateAsync();

        }

        public ObservableCollection<BaseDto> Genders { get; set; }
        public MProp<string> FirstName { get; set; } = new MProp<string>();
        public MProp<string> LastName { get; set; } = new MProp<string>();
        public MProp<string> Email { get; set; } = new MProp<string>();
        public MProp<string> PhoneNumber { get; set; } = new MProp<string>();
        public MProp<bool> AgreedWithTerms { get; set; } = new MProp<bool>();
        public MProp<string> Password { get; set; } = new MProp<string>();
        public MProp<DateTime> DateOfBirth { get; set; } = new MProp<DateTime>();
        public DateTime MaximumDate => DateTime.UtcNow.AddYears(-18);
        public DateTime MinimumDate => DateTime.UtcNow.AddYears(-70);
        public ICommand RegisterCommand { get; set; }
    
        private async Task ValidateAsync()
        {
            var validator = new RegisterViewModelValidator();

            ValidationResult result = validator.Validate(this);

            FirstName.Error = string.Empty;
            LastName.Error = string.Empty;
            Email.Error = string.Empty;
            PhoneNumber.Error = string.Empty;
            Password.Error = string.Empty;

            if(!result.IsValid)
            {
                var firstNameError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("FirstName"));
                if (firstNameError != null) FirstName.Error = firstNameError.ErrorMessage;

                var lastNameError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("LastName"));
                if (lastNameError != null) LastName.Error = lastNameError.ErrorMessage;

                var emailError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("Email"));
                if(emailError != null) Email.Error = emailError.ErrorMessage;

                var phoneError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("PhoneNumber"));
                if (phoneError != null) PhoneNumber.Error = phoneError.ErrorMessage;

                var passwordError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("Password"));
                if (passwordError != null) Password.Error = passwordError.ErrorMessage;
                return;
            }
            var request = new RegisterData
            {
                FirstName = FirstName.Value,
                LastName = LastName.Value,
                Email = Email.Value,
                Password = Password.Value,
                GenderId = 5,
                PhoneNumber = PhoneNumber.Value,
                DateOfBirth = DateOfBirth.Value
            };

            var isRegisterd = _authService.Register(request);

            var snackbarOptions = new SnackbarOptions
            {
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.White,
                CornerRadius = new CornerRadius(10)
            };

            string text = "";
            string actionButtonText = "Click here to dismiss";
            TimeSpan duration = TimeSpan.FromSeconds(3);

            

            

            if (isRegisterd)
            {
                text = "You have successfully registered.";
                snackbarOptions.BackgroundColor = Colors.DarkGreen;
                Application.Current.MainPage = new LoginPage();
            }
            else
            {
                snackbarOptions.BackgroundColor = Colors.Red;
                text = "Unsuccessful attempt to register.";
            }

            var snackbar = Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);
            await snackbar.Show();
        }
        private void GetGenders()
        {
            var genders = _genderService.GetGenders();

            Genders = new ObservableCollection<BaseDto>(genders.ToList());
            OnPropertyChanged(nameof(Genders));
        }
    }
}
