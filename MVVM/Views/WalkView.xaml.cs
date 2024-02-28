using DogWalker.MVVM.ViewModels;

namespace DogWalker.MVVM.Views
{
    /// <summary>
    /// Vista para mostrar la vista de paseo de un perro.
    /// </summary>
    public partial class WalkView : ContentPage
    {
        /// <summary>
        /// Constructor de la clase WalkView.
        /// </summary>
        public WalkView()
        {
            InitializeComponent();
            BindingContext = new WalkViewModel();
        }

        /// <summary>
        /// Evento para retroceder a la vista anterior.
        /// </summary>
        private void Anterior_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        /// <summary>
        /// Evento para ir a la pantalla de inicio.
        /// </summary>
        private void Home_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        /// <summary>
        /// Evento para aceptar la operación actual.
        /// </summary>
        private void Aceptar_Clicked(object sender, EventArgs e)
        {
            WalkViewModel currentView = (WalkViewModel)BindingContext;
            if (!currentView.Error)
            {
                var perroActual = currentView.PerroActual;
                Navigation.PushAsync(new DetailView(perroActual));
            }
        }
    }
}
