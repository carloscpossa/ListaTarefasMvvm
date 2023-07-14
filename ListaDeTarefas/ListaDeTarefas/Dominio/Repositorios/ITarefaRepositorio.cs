using ListaDeTarefas.Dominio.Entidades;
using System.Collections.Generic;

namespace ListaDeTarefas.Dominio.Repositorios
{
    public interface ITarefaRepositorio
    {
        void Adicionar(Tarefa tarefa);
        IReadOnlyCollection<Tarefa> Obter();
    }
}
