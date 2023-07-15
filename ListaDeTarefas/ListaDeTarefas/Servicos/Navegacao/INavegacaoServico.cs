using System;
using System.Threading.Tasks;

namespace ListaDeTarefas.Servicos.Navegacao
{
    public interface INavegacaoServico
    {
        string ChaveDaPaginaAtual { get; }

        void Configurar(string chaveDaPagina, Type tipoDaPagina);
        Task Voltar();
        Task NavegarModalAsync(string chaveDaPagina, bool animacao = true);
        Task NavegarModalAsync(string chaveDaPagina, object parametro, bool animacao = true);
        Task NavegarAsync(string chaveDaPagina, bool animacao = true);
        Task NavegarAsync(string chaveDaPagina, object parametro, bool animacao = true);
    }
}
