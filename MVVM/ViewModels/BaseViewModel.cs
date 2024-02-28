using System;

namespace DogWalker.MVVM.ViewModels
{
    /// <summary>
    /// Clase base para los ViewModels.
    /// </summary>
    public class BaseViewModel
    {
        /// <summary>
        /// Mensaje de estado.
        /// </summary>
        public string StatusMessage { get; set; }

        /// <summary>
        /// Tipo de mensaje.
        /// </summary>
        public string TypeMessage { get; set; }

        /// <summary>
        /// Método para mostrar un mensaje emergente.
        /// </summary>
        /// <param name="title">Título del mensaje.</param>
        /// <param name="message">Contenido del mensaje.</param>
        public void Mensaje(string title, string message)
        {
            App.Current.MainPage.DisplayAlert(title, message, "OK");
        }
    }
}
