using DogWalker.MVVM.Models;
using PropertyChanged;
using System.Collections.Generic;
using System.Windows.Input;

namespace DogWalker.MVVM.ViewModels
{
    /// <summary>
    /// ViewModel para la vista de perros.
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class DogsViewModel : BaseViewModel
    {
        /// <summary>
        /// Lista de perros.
        /// </summary>
        public List<Dog> Perros { get; set; }

        /// <summary>
        /// Perro actual seleccionado.
        /// </summary>
        public Dog PerroActual { get; set; }

        /// <summary>
        /// Indica si la lista de perros está vacía.
        /// </summary>
        public bool ListaVacia { get; set; }

        /// <summary>
        /// Indica si la lista de perros no está vacía.
        /// </summary>
        public bool ListaNoVacia { get; set; }

        /// <summary>
        /// Comando para ver el detalle de un perro.
        /// </summary>
        public ICommand DetalleCommand { get; }

        /// <summary>
        /// Comando para borrar un perro.
        /// </summary>
        public ICommand BorrarCommand { get; }

        /// <summary>
        /// Constructor de la clase DogsViewModel.
        /// </summary>
        public DogsViewModel()
        {
            PerroActual = new Dog();
            DetalleCommand = new Command<int>((id) =>
            {
                PerroActual = App.DogWalkerRepository.GetDog(id);
            });
            BorrarCommand = new Command<int>((id) =>
            {
                PerroActual = App.DogWalkerRepository.GetDog(id);
                App.DogWalkerRepository.DeleteWalks(id);
                App.DogWalkerRepository.DeleteDog(id);
                TypeMessage = App.DogWalkerRepository.TypeMessages;
                StatusMessage = App.DogWalkerRepository.StatusMessages;
                Mensaje(TypeMessage, StatusMessage);
                Actualizar();
            });
        }

        /// <summary>
        /// Actualiza la lista de perros.
        /// </summary>
        public void Actualizar()
        {
            Perros = App.DogWalkerRepository.GetAllDogs();
            ListaVacia = Perros.Count == 0;
            ListaNoVacia = !ListaVacia;
        }
    }
}
