using DogWalker.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DogWalker.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    internal class DogsViewModel
    {
        public List<Dog> Perros;
        public Dog PerroActual;
        public bool ListaVacia;
        public bool ListaNoVacia;
        public ICommand DetalleCommand;
        public ICommand BorrarCommand;
        
        DogsViewModel( BaseViewModel baseView )
        {
            PerroActual = new Dog();
            DetalleCommand = new Command(() => {
            
                PerroActual = App.DogWalkerRepository.GetDog(1);
            
            });
            BorrarCommand = new Command(() =>
            {
                
                PerroActual = App.DogWalkerRepository.GetDog(1);
                App.DogWalkerRepository.DeleteWalks(PerroActual.Id);
                App.DogWalkerRepository.DeleteDog(PerroActual.Id);
                App.DogWalkerRepository.TypeMessages = baseView.TypeMessage;
                App.DogWalkerRepository.StatusMessages = baseView.StatusMessage;
                Actualizar();

            });
        }
        
        public void Actualizar()
        {
            Perros = App.DogWalkerRepository.GetAllDogs();

            ListaVacia = Perros.Count() == 0;
            ListaNoVacia = !ListaVacia;
        }
    }
}
