using DogWalker.MVVM.Repositories;
using DogWalker.MVVM.Views;

namespace DogWalker
{
    /// <summary>
    /// Clase principal de la aplicación.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Repositorio de datos de DogWalker.
        /// </summary>
        public static DogWalkerRepository DogWalkerRepository { get; set; }

        /// <summary>
        /// Constructor de la clase App.
        /// </summary>
        /// <param name="dogWalkerRepository">Repositorio de datos de DogWalker.</param>
        public App(DogWalkerRepository dogWalkerRepository)
        {
            InitializeComponent();
            DogWalkerRepository = dogWalkerRepository;
            MainPage = new NavigationPage(new DogsView());
        }
    }
}
