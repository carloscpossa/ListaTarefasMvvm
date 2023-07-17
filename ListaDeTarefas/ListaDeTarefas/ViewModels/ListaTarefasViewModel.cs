using ListaDeTarefas.Dominio.Entidades;
using ListaDeTarefas.Dominio.Repositorios;
using ListaDeTarefas.Servicos.Navegacao;
using ListaDeTarefas.Views;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
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

            Tarefas = new ObservableRangeCollection<Tarefa>();
            AtualizarListaTarefas();

            IrParaAdicionaTarefaCommand = new Command(async () => await IrParaAdicionaTarefaAsync());
            AtualizarListaTarefasCommand = new Command(AtualizarListaTarefas);
        }

        private int quantidadeTarefas;
        public int QuantidadeTarefas
        {
            get => quantidadeTarefas;
            set => DefinirValor(ref quantidadeTarefas, value);            
        }

        public ObservableRangeCollection<Tarefa> Tarefas { get; set; }

        private bool listaTarefasEmAtualizacao;
        public bool ListaTarefasEmAtualizacao 
        {
            get => listaTarefasEmAtualizacao;
            set => DefinirValor(ref listaTarefasEmAtualizacao, value);
        }

        public ICommand IrParaAdicionaTarefaCommand { get; set; }
        private async Task IrParaAdicionaTarefaAsync()
        {
            await navegacaoServico.NavegarAsync(nameof(AdicionaTarefa));
        }

        public ICommand AtualizarListaTarefasCommand { get; set; }
        private void AtualizarListaTarefas()
        {
            var listaTarefas = this
                .tarefaRepositorio
                .Obter()
                .OrderByDescending(x => x.Prioridade)
                .ThenBy(x => x.TerminoDesejado);

            QuantidadeTarefas = listaTarefas.Count();

            Tarefas.Clear();
            Tarefas.AddRange(listaTarefas);

            ListaTarefasEmAtualizacao = false;
        }
    }
}
