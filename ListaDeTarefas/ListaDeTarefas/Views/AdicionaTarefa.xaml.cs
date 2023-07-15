using ListaDeTarefas.ViewModels;
using Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaDeTarefas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdicionaTarefa : ContentPage
    {
        public AdicionaTarefa()
        {
            InitializeComponent();
            BindingContext = App.ContainerInjecao.Resolve<AdicionaTarefaViewModel>();
        }
    }
}