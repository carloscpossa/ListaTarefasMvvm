using ListaDeTarefas.ViewModels;
using Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaDeTarefas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaTarefas : ContentPage
    {
        public ListaTarefas()
        {
            InitializeComponent();
            BindingContext = App.ContainerInjecao.Resolve<ListaTarefasViewModel>();
        }
    }
}