using ListaDeTarefas.Droid.Arquivo;
using ListaDeTarefas.Servicos.Arquivo;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(ArquivoServico))]
namespace ListaDeTarefas.Droid.Arquivo
{
    public class ArquivoServico : IArquivoServico
    {
        public string ObterLocalDoArquivo(string nomeArquivo)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, nomeArquivo);
        }
    }
}