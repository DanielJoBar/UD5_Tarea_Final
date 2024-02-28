using DogWalker.MVVM.Models;
using DogWalker.MVVM.ViewModels;

namespace DogWalker.MVVM.Views
{
    /// <summary>
    /// Vista para ver los detalles de un perro.
    /// </summary>
    public partial class DetailView : ContentPage
    {
        /// <summary>
        /// Constructor de la clase DetailView.
        /// </summary>
        /// <param name="perroActual">Perro actual cuyos detalles se mostrarán.</param>
        public DetailView(Dog perroActual)
        {
            InitializeComponent();
            BindingContext = new DetailViewModel(perroActual);
        }

        /// <summary>
        /// Evento para retroceder a la vista anterior.
        /// </summary>
        private void Anterior_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        /// <summary>
        /// Evento para ir a la página principal.
        /// </summary>
        private void Home_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        /// <summary>
        /// Evento para iniciar un nuevo paseo.
        /// </summary>
        private void Pasear_Clicked(object sender, EventArgs e)
        {
            var currentViewModel = (DetailViewModel)BindingContext;
            Navigation.PushAsync(new WalkView
            {
                BindingContext = new WalkViewModel
                {
                    PerroActual = currentViewModel.PerroActual
                }
            });
        }

        /// <summary>
        /// Método invocado cuando la vista está apareciendo.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            DetailViewModel currentView = (DetailViewModel)BindingContext;
            currentView.Actualizar();
        }
    }
}
