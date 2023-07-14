using ListaDeTarefas.Dominio.Enumeracoes;
using System;

namespace ListaDeTarefas.Dominio.Entidades
{
    public class Tarefa
    {
        public Tarefa(string descricao, DateTime terminoDesejado, Prioridade prioridade)
        {
            Descricao = descricao;
            TerminoDesejado = terminoDesejado;
            Prioridade = prioridade;
        }

        public string Descricao { get; private set; }
        public DateTime TerminoDesejado { get; private set; }        
        public Prioridade Prioridade { get; private set; }
        public Status Status { get; private set; }
     
        public void Cconcluir()
        {
            Status = Status.Concluida;                           
        }

        public void Cancelar()
        {
            Status = Status.Cancelada;
        }

    }
}
