using DogWalker.MVVM.Repositories;

namespace DogWalker
{
    public partial class App : Application
    {
        public static DogWalkerRepository DogWalkerRepository { get; set; }
        public App(DogWalkerRepository dogWalkerRepository)
        {
            InitializeComponent();
            DogWalkerRepository = dogWalkerRepository;
            MainPage = new AppShell();
        }
    }
}