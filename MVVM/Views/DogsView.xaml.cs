using DogWalker.MVVM.ViewModels;

namespace DogWalker.MVVM.Views
{
    /// <summary>
    /// Vista para mostrar una lista de perros.
    /// </summary>
    public partial class DogsView : ContentPage
    {
        /// <summary>
        /// Constructor de la clase DogsView.
        /// </summary>
        public DogsView()
        {
            InitializeComponent();
            BindingContext = new DogsViewModel();
        }

        /// <summary>
        /// Evento para añadir un nuevo perro.
        /// </summary>
        private void Nuevo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddView()
            {
                BindingContext = new AddViewModel()
            });
        }

        /// <summary>
        /// Evento para ver los detalles de un perro.
        /// </summary>
        private void Detalle_Clicked(object sender, EventArgs e)
        {
            var currentView = (DogsViewModel)BindingContext;
            var perroActual = currentView.PerroActual;
            Navigation.PushAsync(new DetailView(perroActual)
            {
                BindingContext = new DetailViewModel(perroActual)
            });
        }

        /// <summary>
        /// Método invocado cuando la vista está apareciendo.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var currentView = (DogsViewModel)BindingContext;
            currentView.Actualizar();
        }
    }
}
