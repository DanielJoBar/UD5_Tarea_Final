using DogWalker.MVVM.Models;
using DogWalker.MVVM.Repositories;
using System;
using System.Windows.Input;

namespace DogWalker.MVVM.ViewModels
{
    /// <summary>
    /// ViewModel para agregar un nuevo perro.
    /// </summary>
    public class AddViewModel : BaseViewModel
    {
        /// <summary>
        /// Perro actual que se está agregando.
        /// </summary>
        public Dog PerroActual { get; set; }

        /// <summary>
        /// Comando para agregar un nuevo perro.
        /// </summary>
        public ICommand AddDogCommand { get; }

        /// <summary>
        /// Indica si se produjo un error durante la adición del perro.
        /// </summary>
        public bool Error { get; private set; }

        /// <summary>
        /// Constructor de la clase AddViewModel.
        /// </summary>
        public AddViewModel()
        {
            PerroActual = new Dog();
            AddDogCommand = new Command(() =>
            {
                if (String.IsNullOrEmpty(PerroActual.Nombre))
                {
                    TypeMessage = "ERROR";
                    StatusMessage = "El nombre es obligatorio";
                    Error = true;
                }
                else if (String.IsNullOrEmpty(PerroActual.Raza))
                {
                    TypeMessage = "ERROR";
                    StatusMessage = "La raza es obligatoria";
                    Error = true;
                }
                else if (PerroActual.Nombre.Length > 20)
                {
                    TypeMessage = "ERROR";
                    StatusMessage = "El Nombre solo puede tener 20 caracteres como máximo";
                    Error = true;
                }
                else if (PerroActual.Raza.Length > 20)
                {
                    TypeMessage = "ERROR";
                    StatusMessage = "La Raza solo puede tener 20 caracteres como máximo";
                    Error = true;
                }
                else
                {
                    App.DogWalkerRepository.AddDog(PerroActual);
                    TypeMessage = App.DogWalkerRepository.TypeMessages;
                    StatusMessage = App.DogWalkerRepository.StatusMessages;
                    Error = TypeMessage.Equals(Constantes.ERROR_MESSAGE);
                }
                Mensaje(TypeMessage, StatusMessage);
            });
        }
    }
}
