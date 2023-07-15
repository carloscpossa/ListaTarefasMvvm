using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListaDeTarefas.Servicos.Navegacao
{
    public class NavegacaoServico : INavegacaoServico
    {
        private readonly object _sync = new object();
        private readonly Dictionary<string, Type> _paginasPorChaves = new Dictionary<string, Type>();
        private readonly Stack<NavigationPage> _pilhaDeNavegacaoDePaginas =
            new Stack<NavigationPage>();
        private NavigationPage PaginaDeNavegacaoAtual => _pilhaDeNavegacaoDePaginas.Peek();

        public void Configurar(string chaveDaPagina, Type tipoDaPagina)
        {
            lock (_sync)
            {
                if (_paginasPorChaves.ContainsKey(chaveDaPagina))
                {
                    _paginasPorChaves[chaveDaPagina] = tipoDaPagina;
                }
                else
                {
                    _paginasPorChaves.Add(chaveDaPagina, tipoDaPagina);
                }
            }
        }

        public Page DefinirPaginaPrincipal(string chaveDaPaginaPrincipal)
        {
            var rootPage = ObterPagina(chaveDaPaginaPrincipal);
            _pilhaDeNavegacaoDePaginas.Clear();
            var mainPage = new NavigationPage(rootPage);
            _pilhaDeNavegacaoDePaginas.Push(mainPage);
            return mainPage;
        }

        public string ChaveDaPaginaAtual
        {
            get
            {
                lock (_sync)
                {
                    if (PaginaDeNavegacaoAtual?.CurrentPage == null)
                    {
                        return null;
                    }

                    var pageType = PaginaDeNavegacaoAtual.CurrentPage.GetType();
                    
                    return _paginasPorChaves.ContainsValue(pageType)
                        ? _paginasPorChaves.First(p => p.Value == pageType).Key
                        : null;
                }
            }
        }

        public async Task Voltar()
        {
            var navigationStack = PaginaDeNavegacaoAtual.Navigation;
            if (navigationStack.NavigationStack.Count > 1)
            {
                await PaginaDeNavegacaoAtual.PopAsync();
                return;
            }

            if (_pilhaDeNavegacaoDePaginas.Count > 1)
            {
                _pilhaDeNavegacaoDePaginas.Pop();
                await PaginaDeNavegacaoAtual.Navigation.PopModalAsync();
                return;
            }

            await PaginaDeNavegacaoAtual.PopAsync();
        }

        public async Task NavegarModalAsync(string chaveDaPagina, bool animacao = true)
        {
            await NavegarModalAsync(chaveDaPagina, null, animacao);
        }

        public async Task NavegarModalAsync(string chaveDaPagina, object parametro, bool animacao = true)
        {
            var page = ObterPagina(chaveDaPagina, parametro);
            NavigationPage.SetHasNavigationBar(page, false);
            var modalNavigationPage = new NavigationPage(page);
            await PaginaDeNavegacaoAtual.Navigation.PushModalAsync(modalNavigationPage, animacao);
            _pilhaDeNavegacaoDePaginas.Push(modalNavigationPage);
        }

        public async Task NavegarAsync(string chaveDaPagina, bool animacao = true)
        {
            await NavegarAsync(chaveDaPagina, null, animacao);
        }

        public async Task NavegarAsync(string chaveDaPagina, object parametro, bool animacao = true)
        {
            var page = ObterPagina(chaveDaPagina, parametro);
            await PaginaDeNavegacaoAtual.Navigation.PushAsync(page, animacao);
        }

        private Page ObterPagina(string chaveDaPagina, object parametro = null)
        {

            lock (_sync)
            {
                if (!_paginasPorChaves.ContainsKey(chaveDaPagina))
                {
                    throw new ArgumentException(
                        $"Página não encontrada: {chaveDaPagina}. É necessário realizar a configuração através do método NavigationService.Configure.");
                }

                var type = _paginasPorChaves[chaveDaPagina];
                ConstructorInfo constructor;
                object[] parametros;

                if (parametro == null)
                {
                    constructor = type.GetTypeInfo()
                        .DeclaredConstructors
                        .FirstOrDefault(c => !c.GetParameters().Any());

                    parametros = new object[]
                    {
                    };
                }
                else
                {
                    constructor = type.GetTypeInfo()
                        .DeclaredConstructors
                        .FirstOrDefault(
                            c =>
                            {
                                var p = c.GetParameters();
                                return p.Length == 1
                                       && p[0].ParameterType == parametro.GetType();
                            });

                    parametros = new[]
                    {
                        parametro
                    };
                }

                if (constructor == null)
                {
                    throw new InvalidOperationException(
                        "No suitable constructor found for page " + chaveDaPagina);
                }

                var page = constructor.Invoke(parametros) as Page;
                return page;
            }
        }
    }
}
