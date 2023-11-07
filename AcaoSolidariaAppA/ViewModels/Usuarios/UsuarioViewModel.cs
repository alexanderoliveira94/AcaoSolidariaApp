using AcaoSolidariaAppA.Services.Usuarios;
using System.Windows.Input;
using AcaoSolidariaAppA.Models;
using System.Net.Mail;
using AcaoSolidariaAppA.Views.Usuarios;
using AcaoSolidariaAppA.Views;

namespace AcaoSolidariaAppA.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
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

        public async Task RegistrarUsuario()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Nome) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(SenhaUsuario))
                {
                    throw new Exception("Os campos Nome, E-mail e Senha são obrigatórios.");
                }

                if (string.IsNullOrWhiteSpace(DescricaoHabilidades))
                {
                    throw new Exception("O campo Descrição de Habilidades é obrigatório.");
                }

                if (!IsValidEmail(Email))
                {
                    throw new Exception("O e-mail fornecido não é válido.");
                }

                Usuario u = new Usuario
                {
                    Nome = Nome,
                    Email = Email,
                    DescricaoHabilidades = DescricaoHabilidades,
                    SenhaUsuario = SenhaUsuario
                };

                await uService.PostRegistrarUsuarioAsync(u);

                string mensagem = $"Bem-vindo, {u.Nome}!";
                await App.Current.MainPage.DisplayAlert("Sucesso", mensagem, "Ok");
                Application.Current.MainPage = new NavigationPage(new BoasVindasView());
            }
            catch (HttpRequestException)
            {
                await App.Current.MainPage.DisplayAlert("Erro de conexão", "Verifique sua conexão com a internet e tente novamente.", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        


        private CancellationTokenSource _cancelTokenSource;

        public async Task AutenticarUsuario()//Método para autenticar um usuário     
        {
            try
            {
                Usuario u = new Usuario();
                u.Email = Email;
                u.SenhaUsuario = SenhaUsuario;

                Usuario uAutenticado = await uService.PostAutenticarUsuarioAsync(u);

                if (!string.IsNullOrEmpty(uAutenticado.Token))
                {
                    string mensagem = $"Bem-vindo(a) {uAutenticado.Nome}.";

                    //Guardando dados do usuário para uso futuro
                    Preferences.Set("UsuarioId", uAutenticado.IdUsuario);
                    Preferences.Set("UsuarioEmail", uAutenticado.Email);
                    Preferences.Set("UsuarioSenha", uAutenticado.SenhaUsuario);
                    Preferences.Set("UsuarioToken", uAutenticado.Token);


                    await Application.Current.MainPage
                            .DisplayAlert("Informação", mensagem, "Ok");

                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    await Application.Current.MainPage
                        .DisplayAlert("Informação", "Dados incorretos :(", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaCadastro()
        {
            try
            {
                await App.Current.MainPage.Navigation.PushAsync(new EscolhaOngVoluntario());
            }
            catch (HttpRequestException)
            {
                await App.Current.MainPage.DisplayAlert("Erro de conexão", "Verifique sua conexão com a internet e tente novamente.", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}
