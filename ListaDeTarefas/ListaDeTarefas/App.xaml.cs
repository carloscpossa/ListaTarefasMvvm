using ListaDeTarefas.Dominio.Repositorios;
using ListaDeTarefas.Repositorios;
using ListaDeTarefas.Servicos.Navegacao;
using ListaDeTarefas.Views;
using Unity;
using Xamarin.Forms;

namespace ListaDeTarefas
{
    public partial class App : Application
    {
        private static IUnityContainer container;
        private static INavegacaoServico navegacaoServico;


        public static IUnityContainer ContainerInjecao
            => container;

        public App()
        {            
            InitializeComponent();

            RegistrarDependencias();
            ConfigurarPaginasNavegacao();
            
            MainPage = ((NavegacaoServico)navegacaoServico).DefinirPaginaPrincipal(nameof(ListaTarefas));
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

            navegacaoServico = container.Resolve<NavegacaoServico>();            

            container.RegisterInstance<INavegacaoServico>(navegacaoServico);

        }

        private static void ConfigurarPaginasNavegacao()
        {
            navegacaoServico.Configurar(nameof(ListaTarefas), typeof(ListaTarefas));
            navegacaoServico.Configurar(nameof(AdicionaTarefa), typeof(AdicionaTarefa));            
        }
    }
}
