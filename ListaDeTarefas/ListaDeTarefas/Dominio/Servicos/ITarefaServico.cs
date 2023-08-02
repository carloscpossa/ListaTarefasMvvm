using System;

namespace ListaDeTarefas.Dominio.Servicos
{
    public interface ITarefaServico
    {
        void AdicionarTarefa(string descricao, DateTime terminoDesejado);
    }
}
