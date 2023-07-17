using ListaDeTarefas.Dominio.Servicos;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListaDeTarefas.ViewModels
{
    public class AdicionaTarefaViewModel : BaseViewModel
    {
        private readonly ITarefaServico tarefaServico;
        public AdicionaTarefaViewModel(ITarefaServico tarefaServico)
        {
            this.tarefaServico = tarefaServico;

            SalvarTarefaCommand = new Command(SalvarTarefa);
        }

        private string descricao = "";
        public string Descricao 
        {
            get => descricao;
            set => DefinirValor(ref descricao, value);
        }

        public ICommand SalvarTarefaCommand { get; set; }

        private string mensagemSucesso = "";
        public string MensagemSucesso
        {
            get => mensagemSucesso;
            set => DefinirValor(ref mensagemSucesso, value);
        }

        private string mensagemErro = "";
        public string MensagemErro 
        {
            get => mensagemErro;
            set => DefinirValor(ref mensagemErro, value);
        }

        private void SalvarTarefa()
        {
            MensagemSucesso = "";
            MensagemErro = "";
            try
            {
                tarefaServico.AdicionarTarefa(Descricao);
                MensagemSucesso = "Tarefa adicionada com sucesso!";                
            }
            catch (Exception ex)
            {
                MensagemErro = $"Erro ao adicionar tarefa! {ex.Message}";
            }
        }
    }
}
