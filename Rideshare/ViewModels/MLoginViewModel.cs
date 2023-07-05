using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using Rideshare.Business;
using Rideshare.Business.Services;
using Rideshare.Common;
using Rideshare.Pages;
using Rideshare.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rideshare.ViewModels
{
    public class MLoginViewModel : BaseViewModel
    {
        public MLoginViewModel()
        {
          
            Email.Value = "";

            LoginCommand = new Command(Login);
        }

        private async void Login()
        {
            AuthService authService = new AuthService();

            Actor actor = authService.Auth(this.Email.Value, this.Password.Value);

            if (string.IsNullOrEmpty(actor.Token))
            {
                InvalidCredentials = "Wrong email or password.";

                OnPropertyChanged(nameof(InvalidCredentials));
                return;
            }
            await SecureStorage.Default.SetAsync("jwt", actor.Token);
            await SecureStorage.Default.SetAsync("Actor", JsonConvert.SerializeObject(actor));

            Application.Current.MainPage = new LoggedInPage();
        }

        public MProp<string> Email { get; set; } = new MProp<string>();
        public MProp<string> Password { get; set; } = new MProp<string>();
        public string InvalidCredentials { get; set; }
        public ICommand LoginCommand { get; set; }



    }
}
