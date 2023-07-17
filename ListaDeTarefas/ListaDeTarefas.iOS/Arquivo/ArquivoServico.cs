using ListaDeTarefas.iOS.Arquivo;
using ListaDeTarefas.Servicos.Arquivo;
using System.IO;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(ArquivoServico))]
namespace ListaDeTarefas.iOS.Arquivo
{
    public class ArquivoServico : IArquivoServico
    {
        public string ObterLocalDoArquivo(string nomeArquivo)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, nomeArquivo);
        }
    }
}