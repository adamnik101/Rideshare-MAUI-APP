using FluentValidation.Results;
using Rideshare.Common;
using Rideshare.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.ViewModels
{
    public class MRegisterViewModel : BaseViewModel
    {
        public MRegisterViewModel()
        {
            FirstName.OnValueChange = Validate;
            LastName.OnValueChange = Validate;
            Email.OnValueChange = Validate;
            PhoneNumber.OnValueChange = Validate;
        }

        public MProp<string> FirstName { get; set; } = new MProp<string>();
        public MProp<string> LastName { get; set; } = new MProp<string>();
        public MProp<string> Email { get; set; } = new MProp<string>();
        public MProp<string> PhoneNumber { get; set; } = new MProp<string>();
        public MProp<bool> AgreedWithTerms { get; set; } = new MProp<bool>();
        public DateTime MaximumDate => DateTime.UtcNow.AddYears(-18);
        public DateTime MinimumDate => DateTime.UtcNow.AddYears(-70);
        public bool IsRegisterButtonEnabled => !FirstName.HasError && !LastName.HasError && !Email.HasError && !PhoneNumber.HasError;
    
        private void Validate()
        {
            var validator = new RegisterViewModelValidator();

            ValidationResult result = validator.Validate(this);

            FirstName.Error = string.Empty;
            LastName.Error = string.Empty;
            Email.Error = string.Empty;
            PhoneNumber.Error = string.Empty;

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
            }

            OnPropertyChanged(nameof(IsRegisterButtonEnabled));
        }
    }
}
