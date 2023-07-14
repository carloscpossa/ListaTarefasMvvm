using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ListaDeTarefas.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void AposPropriedadeAlterada([CallerMemberName] string nomeDaPropriedade = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomeDaPropriedade));
        }

        public void DefinirValor<T>(ref T atributo, T valor, [CallerMemberName] string nomeDaPropriedade = null)
        {
            if (EqualityComparer<T>.Default.Equals(atributo, valor))
                return;

            atributo = valor;
            AposPropriedadeAlterada(nomeDaPropriedade);
        }
    }
}
