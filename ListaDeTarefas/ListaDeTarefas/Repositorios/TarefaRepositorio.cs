using ListaDeTarefas.Dominio.Entidades;
using ListaDeTarefas.Dominio.Repositorios;
using System.Collections.Generic;

namespace ListaDeTarefas.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private static Dictionary<int, Tarefa> armazenamentoTarefas = new Dictionary<int, Tarefa>();

        public void Adicionar(Tarefa tarefa)
        {
            armazenamentoTarefas.Add(armazenamentoTarefas.Count + 1, tarefa);
        }

        public IReadOnlyCollection<Tarefa> Obter()
            => armazenamentoTarefas.Values;
    }
}
