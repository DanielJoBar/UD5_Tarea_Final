using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker.MVVM.ViewModels
{
    internal class BaseViewModel
    {
        public string StatusMessage { get; set; }
        public string TypeMessage   { get; set; }
        public void Mensaje (string title, string message)
        {
            App.Current.MainPage.DisplayAlert(title, message, "OK");
        }
    }
}
