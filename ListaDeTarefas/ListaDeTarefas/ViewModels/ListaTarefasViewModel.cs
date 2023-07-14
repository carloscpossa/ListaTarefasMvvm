using ListaDeTarefas.Dominio.Repositorios;

namespace ListaDeTarefas.ViewModels
{
    public class ListaTarefasViewModel : BaseViewModel
    {
        private readonly ITarefaRepositorio tarefaRepositorio;
        public ListaTarefasViewModel(ITarefaRepositorio tarefaRepositorio)
        {
            this.tarefaRepositorio = tarefaRepositorio;

            Nome = "Tarefas do Carlos";
        }

        private string nome = "";
        public string Nome 
        {
            get => nome;
            set => DefinirValor(ref nome, value);
            
        }
    }
}
