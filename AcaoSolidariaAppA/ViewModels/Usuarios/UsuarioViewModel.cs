using AcaoSolidariaAppA.Services.Usuarios;
using System.Windows.Input;
using AcaoSolidariaAppA.Models;

namespace AcaoSolidariaAppA.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {


        public UsuarioViewModel()
        {
            uService = new UsuarioService();
            InicializarCommands();
        }


        public void InicializarCommands()
        {
            RegistrarCommand = new Command(async () => await RegistrarUsuario());
            AutenticarCommand = new Command(async () => await AutenticarUsuario());
            DirecionarCadastroCommand = new Command(async () => await DirecionarParaCadastro());
        }

        private UsuarioService uService;

        public ICommand RegistrarCommand { get; set; }
        public ICommand AutenticarCommand { get; set; }
        public ICommand DirecionarCadastroCommand { get; set; }

        private string _nome = string.Empty;
        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
                OnPropertyChanged();
            }
        }

        private string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _descricaoHabilidades = string.Empty;
        public string DescricaoHabilidades
        {
            get { return _descricaoHabilidades; }
            set
            {
                _descricaoHabilidades = value;
                OnPropertyChanged();
            }
        }

        private string _senhaUsuario = string.Empty;
        public string SenhaUsuario
        {
            get { return _senhaUsuario; }
            set
            {
                _senhaUsuario = value;
                OnPropertyChanged();
            }
        }



        public async Task RegistrarUsuario()//M�todo para registrar um usu�rio     
        {
            try
            {
                Usuario u = new Usuario();
                u.Nome = Nome;
                u.Email = Email;
                u.DescricaoHabilidades = DescricaoHabilidades;
                u.SenhaUsuario = SenhaUsuario;

                Usuario uRegistrado = await uService.PostRegistrarUsuarioAsync(u);

                if (uRegistrado.IdUsuario != 0)
                {
                    string mensagem = $"Usu�rio Id {uRegistrado.IdUsuario} registrado com sucesso.";
                    await Application.Current.MainPage.DisplayAlert("Informa��o", mensagem, "Ok");

                    await Application.Current.MainPage
                        .Navigation.PopAsync();//Remove a p�gina da pilha de visualiza��o
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informa��o", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
                Console.WriteLine(ex.Message); // Imprime a mensagem da exce��o
                Console.WriteLine(ex.StackTrace); // Imprime a pilha de chamadas
            }
        }


        private CancellationTokenSource _cancelTokenSource;
        
        public async Task AutenticarUsuario()//M�todo para autenticar um usu�rio     
        {
            try
            {
                Usuario u = new Usuario();
                u.Nome = Nome;
                u.Email = Email;
                u.DescricaoHabilidades = DescricaoHabilidades;
                u.SenhaUsuario = SenhaUsuario;

                Usuario uAutenticado = await uService.PostAutenticarUsuarioAsync(u);

                if (!string.IsNullOrEmpty(uAutenticado.Token))
                {
                    string mensagem = $"Bem-vindo(a) {uAutenticado.Email}.";

                    //Guardando dados do usu�rio para uso futuro
                    Preferences.Set("UsuarioId", uAutenticado.IdUsuario);
                    Preferences.Set("UsuarioUsername", uAutenticado.Email);
                    Preferences.Set("UsuarioToken", uAutenticado.Token);

                   await Application.Current.MainPage
                            .DisplayAlert("Informa��o", mensagem, "Ok");

                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    await Application.Current.MainPage
                        .DisplayAlert("Informa��o", "Dados incorretos :(", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informa��o", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaCadastro()//M�todo para exibi��o da view de Cadastro      
        {
            try
            {
                await Application.Current.MainPage.
                    Navigation.PushAsync(new Views.BoasVindasView());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informa��o", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

    }
}