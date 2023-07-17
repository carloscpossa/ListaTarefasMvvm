using ListaDeTarefas.Dominio.Entidades;
using ListaDeTarefas.Dominio.Repositorios;
using LiteDB;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ListaDeTarefas.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {        
        private readonly ILiteDatabase bancoDados;
        

        public TarefaRepositorio(ILiteDatabase bancoDados)
        {
            this.bancoDados = bancoDados;
        }

        public void Adicionar(Tarefa tarefa)
        {
            var colecao = bancoDados.GetCollection<Tarefa>();
            colecao.Insert(tarefa);
        }

        public IReadOnlyCollection<Tarefa> Obter()
        {
            var colecao = bancoDados.GetCollection<Tarefa>();
            return colecao
                .FindAll()
                .ToList();
        }
    }
}
