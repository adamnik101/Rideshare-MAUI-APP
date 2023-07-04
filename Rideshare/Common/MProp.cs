using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Common
{
    public class MProp<T> : INotifyPropertyChanged
    {
        private T _value;
        private string _error;
        private Action _onValueChange;
            
        public Action OnValueChange
        {
            set { _onValueChange = value; }
        }
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();

                _onValueChange?.Invoke();

            }
        }
        public bool HasError => !string.IsNullOrEmpty(_error);

        public string Error
        {
            get => _error;
            set
            {
                _error = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasError));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
