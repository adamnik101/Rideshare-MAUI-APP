using Rideshare.Business;
using Rideshare.Business.DTOs;
using Rideshare.Business.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Common
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;   
        public void OnPropertyChanged([CallerMemberName] string name = "") => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
