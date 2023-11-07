using AcaoSolidariaAppA.Services.Usuarios;
using System.Windows.Input;
using AcaoSolidariaAppA.Models;
using System.Net.Mail;

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
                    throw new Exception("Os campos Nome, E-mail e Senha s�o obrigat�rios.");
                }

                if (string.IsNullOrWhiteSpace(DescricaoHabilidades))
                {
                    throw new Exception("O campo Descri��o de Habilidades � obrigat�rio.");
                }

                if (!IsValidEmail(Email))
                {
                    throw new Exception("O e-mail fornecido n�o � v�lido.");
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
                await Application.Current.MainPage.DisplayAlert("Sucesso", mensagem, "Ok");
                Application.Current.MainPage = new NavigationPage(new Views.BoasVindasView());
            }
            catch (HttpRequestException)
            {
                await Application.Current.MainPage.DisplayAlert("Erro de conex�o", "Verifique sua conex�o com a internet e tente novamente.", "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public async Task AutenticarUsuario()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Nome))
                {
                    throw new Exception("Por favor, insira um nome v�lido.");
                }

                if (string.IsNullOrWhiteSpace(Email))
                {
                    throw new Exception("Por favor, insira um endere�o de e-mail v�lido.");
                }

                if (string.IsNullOrWhiteSpace(SenhaUsuario))
                {
                    throw new Exception("Por favor, insira uma senha v�lida.");
                }

                Usuario u = new Usuario
                {
                    Nome = Nome,
                    Email = Email,
                    DescricaoHabilidades = DescricaoHabilidades,
                    SenhaUsuario = SenhaUsuario
                };

                Usuario uAutenticado = await uService.PostAutenticarUsuarioAsync(u);

                if (!string.IsNullOrEmpty(uAutenticado.Token))
                {
                    string mensagem = $"Bem-vindo(a) {uAutenticado.Email}.";

                    // Guardando dados do usu�rio para uso futuro
                    Preferences.Set("UsuarioId", uAutenticado.IdUsuario);
                    Preferences.Set("UsuarioUsername", uAutenticado.Email);
                    Preferences.Set("UsuarioToken", uAutenticado.Token);

                    await Application.Current.MainPage.DisplayAlert("Informa��o", mensagem, "Ok");

                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Informa��o", "Credenciais de autentica��o incorretas. Por favor, tente novamente.", "Ok");
                }
            }
            catch (HttpRequestException)
            {
                await Application.Current.MainPage.DisplayAlert("Erro de conex�o", "Verifique sua conex�o com a internet e tente novamente.", "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public async Task DirecionarParaCadastro()
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Views.BoasVindasView());
            }
            catch (HttpRequestException)
            {
                await Application.Current.MainPage.DisplayAlert("Erro de conex�o", "Verifique sua conex�o com a internet e tente novamente.", "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
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
