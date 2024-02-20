using DogWalker.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    internal class DogsViewModel
    {
        public List<Dog> Perros;
        public Dog PerroActual;

    }
}
