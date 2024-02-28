using DogWalker.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DogWalker.MVVM.ViewModels
{
    /// <summary>
    /// ViewModel para la vista de detalle.
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    internal class DetailViewModel : BaseViewModel
    {
        /// <summary>
        /// Perro actual.
        /// </summary>
        public Dog PerroActual { get; set; }

        /// <summary>
        /// Lista de paseos.
        /// </summary>
        public List<Walk> Paseos { get; set; }

        /// <summary>
        /// Paseo actual seleccionado.
        /// </summary>
        public Walk PaseoActual { get; set; }

        /// <summary>
        /// Indica si la lista de paseos está vacía.
        /// </summary>
        public bool ListaVacia { get; set; }

        /// <summary>
        /// Indica si la lista de paseos no está vacía.
        /// </summary>
        public bool ListaNoVacia { get; set; }

        /// <summary>
        /// Comando para pasear.
        /// </summary>
        public ICommand PasearCommand { get; set; }

        /// <summary>
        /// Comando para borrar un paseo.
        /// </summary>
        public ICommand BorrarCommand { get; set; }

        /// <summary>
        /// Constructor de la clase DetailViewModel.
        /// </summary>
        /// <param name="perroActual">Perro actual.</param>
        public DetailViewModel(Dog perroActual)
        {
            PaseoActual = new Walk();
            PerroActual = perroActual;
            BorrarCommand = new Command<int>((id) =>
            {
                PaseoActual = App.DogWalkerRepository.GetWalk(id);
                App.DogWalkerRepository.DeleteWalk(id);
                TypeMessage = App.DogWalkerRepository.TypeMessages;
                StatusMessage = App.DogWalkerRepository.StatusMessages;
                Mensaje(TypeMessage, StatusMessage);
                Actualizar();
            });
        }

        /// <summary>
        /// Actualiza la lista de paseos.
        /// </summary>
        public void Actualizar()
        {
            Paseos = App.DogWalkerRepository.GetWalks(PerroActual.Id);
            ListaVacia = Paseos.Count() == 0;
            ListaNoVacia = !ListaVacia;
        }
    }
}
