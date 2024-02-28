using DogWalker.MVVM.Models;
using DogWalker.MVVM.Repositories;
using System;
using System.Windows.Input;

namespace DogWalker.MVVM.ViewModels
{
    /// <summary>
    /// ViewModel para la vista de agregar paseo.
    /// </summary>
    internal class WalkViewModel : BaseViewModel
    {
        /// <summary>
        /// Perro actual asociado al paseo.
        /// </summary>
        public Dog PerroActual { get; set; }

        /// <summary>
        /// Paseo que se va a agregar.
        /// </summary>
        public Walk Paseo { get; set; }

        /// <summary>
        /// Comando para agregar un paseo.
        /// </summary>
        public ICommand AddWalkCommand { get; set; }

        /// <summary>
        /// Indica si ha ocurrido un error.
        /// </summary>
        public bool Error { get; set; }

        /// <summary>
        /// Constructor de la clase WalkViewModel.
        /// </summary>
        public WalkViewModel()
        {
            Paseo = new Walk();
            Paseo.Fecha = DateTime.Now;
            AddWalkCommand = new Command(() =>
            {
                if (Paseo.Inicio < Paseo.Fin && Paseo.Fecha.Year >= DateTime.Now.Year && Paseo.Fecha.Month >= DateTime.Now.Month && Paseo.Fecha.Day >= DateTime.Now.Day)
                {
                    Paseo.PerroID = PerroActual.Id;
                    App.DogWalkerRepository.AddWalk(Paseo);
                    TypeMessage = App.DogWalkerRepository.TypeMessages;
                    StatusMessage = App.DogWalkerRepository.StatusMessages;
                    Error = TypeMessage.Equals(Constantes.ERROR_MESSAGE);
                }
                else if (Paseo.Inicio < Paseo.Fin)
                {
                    TypeMessage = "ERROR";
                    StatusMessage = "La hora de inicio del paseo debe ser menor que la hora de fin";
                    Error = true;
                }
                else
                {
                    TypeMessage = "ERROR";
                    StatusMessage = "Introduzca una fecha válida";
                    Error = true;
                }

                Mensaje(TypeMessage, StatusMessage);
            });
        }
    }
}
