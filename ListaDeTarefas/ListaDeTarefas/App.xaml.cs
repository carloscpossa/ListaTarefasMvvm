using ListaDeTarefas.Dominio.Repositorios;
using ListaDeTarefas.Repositorios;
using ListaDeTarefas.ViewModels;
using ListaDeTarefas.Views;
using Unity;
using Xamarin.Forms;

namespace ListaDeTarefas
{
    public partial class App : Application
    {
        private static IUnityContainer container;

        public static IUnityContainer ContainerInjecao
            => container;

        public App()
        {
            RegistrarDependencias();

            InitializeComponent();

            MainPage = new NavigationPage(container.Resolve<ListaTarefas>());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private static void RegistrarDependencias()
        {
            container = new UnityContainer();

            container.RegisterType<ITarefaRepositorio, TarefaRepositorio>();
            
        }
    }
}
