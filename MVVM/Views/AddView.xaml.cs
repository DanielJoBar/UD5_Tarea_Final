using DogWalker.MVVM.ViewModels;

namespace DogWalker.MVVM.Views
{
    /// <summary>
    /// Vista para agregar un nuevo perro.
    /// </summary>
    public partial class AddView : ContentPage
    {
        /// <summary>
        /// Constructor de la clase AddView.
        /// </summary>
        public AddView()
        {
            InitializeComponent();
            BindingContext = new AddViewModel();
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
        /// Evento para aceptar la acción y navegar a la vista de perros.
        /// </summary>
        private void Aceptar_Clicked(object sender, EventArgs e)
        {
            AddViewModel currentView = (AddViewModel)BindingContext;
            if (!currentView.Error)
            {
                Navigation.PushAsync(new DogsView());
            }
        }
    }
}
