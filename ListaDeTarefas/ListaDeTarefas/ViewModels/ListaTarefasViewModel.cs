using ListaDeTarefas.Dominio.Repositorios;
using ListaDeTarefas.Servicos.Navegacao;
using ListaDeTarefas.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListaDeTarefas.ViewModels
{
    public class ListaTarefasViewModel : BaseViewModel
    {
        private readonly ITarefaRepositorio tarefaRepositorio;
        private readonly INavegacaoServico navegacaoServico;
        public ListaTarefasViewModel(ITarefaRepositorio tarefaRepositorio, INavegacaoServico navegacaoServico)
        {
            this.tarefaRepositorio = tarefaRepositorio;
            this.navegacaoServico = navegacaoServico;

            Nome = "Tarefas do Carlos";
            IrParaAdicionaTarefaCommand = new Command(async () => await IrParaAdicionaTarefaAsync());            
        }

        private string nome = "";
        public string Nome 
        {
            get => nome;
            set => DefinirValor(ref nome, value);            
        }

        public ICommand IrParaAdicionaTarefaCommand { get; set; }
        private async Task IrParaAdicionaTarefaAsync()
        {
            await navegacaoServico.NavegarAsync(nameof(AdicionaTarefa));
        }

    }
}
