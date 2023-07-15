using ListaDeTarefas.Dominio.Repositorios;

namespace ListaDeTarefas.ViewModels
{
    public class AdicionaTarefaViewModel : BaseViewModel
    {
        private readonly ITarefaRepositorio tarefaRepositorio;

        public AdicionaTarefaViewModel(ITarefaRepositorio tarefaRepositorio)
        {
            this.tarefaRepositorio = tarefaRepositorio;
        }
    }
}
