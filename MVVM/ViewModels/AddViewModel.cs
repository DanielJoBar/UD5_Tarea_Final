using DogWalker.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DogWalker.MVVM.ViewModels
{
    internal class AddViewModel
    {
        public Dog PerroActual;
        public ICommand AddDogCommand;
        public bool Error;
        public AddViewModel() 
        {
            PerroActual = new Dog();
            AddDogCommand = new Command(() =>
            {
                if (!(PerroActual==null))
                {
                    if(PerroActual.Nombre == "")
                    {
                        
                    }
                }
            });
        }
    }
}
