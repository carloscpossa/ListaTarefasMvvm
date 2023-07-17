using ListaDeTarefas.Dominio.Entidades;
using ListaDeTarefas.Dominio.Enumeracoes;
using ListaDeTarefas.Dominio.Repositorios;
using System;

namespace ListaDeTarefas.Dominio.Servicos
{
    public class TarefaServico : ITarefaServico
    {
        private readonly ITarefaRepositorio tarefaRepositorio;
        public TarefaServico(ITarefaRepositorio tarefaRepositorio)
        {
            this.tarefaRepositorio = tarefaRepositorio;
        }
        public void AdicionarTarefa(string descricao)
        {
            var tarefa = new Tarefa(descricao, DateTime.Now.AddDays(7), Prioridade.Media);
            tarefaRepositorio.Adicionar(tarefa);
        }
    }
}
