using AcaoSolidariaAppA.Services.Usuarios;
using System.Windows.Input;
using AcaoSolidariaAppA.Models;
using System.Net.Mail;
using AcaoSolidariaAppA.Views.Usuarios;
using AcaoSolidariaAppA.Views;
using AcaoSolidariaApp.ViewModels.PublicacaoViewModel;

namespace AcaoSolidariaAppA.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        public UsuarioViewModel()
        {
            uService = new UsuarioService();
            PublicacaoVM = new PublicacaoViewModel();
            InicializarCommands();
        }

        public void InicializarCommands()
        {
            RegistrarCommand = new Command(async () => await RegistrarUsuario());
            AutenticarCommand = new Command(async () => await AutenticarUsuario());
            DirecionarCadastroCommand = new Command(async () => await DirecionarParaCadastro());
            DesconectarCommand = new Command(async () => await DesconectarUsuario());
            AlterarCadastroCommand = new Command(async () => await AlterarCadastro());
            
        }

        private UsuarioService uService;



        public ICommand RegistrarCommand { get; set; }
        public ICommand AutenticarCommand { get; set; }
        public ICommand DirecionarCadastroCommand { get; set; }
        public ICommand DesconectarCommand { get; set; }
        public ICommand AlterarCadastroCommand { get; set; }
        

        private PublicacaoViewModel _publicacaoViewModel;
        public PublicacaoViewModel PublicacaoVM
        {
            get => _publicacaoViewModel;
            set
            {
                _publicacaoViewModel = value;
                OnPropertyChanged();
            }
        }

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
                await App.Current.MainPage.DisplayAlert("Sucesso", mensagem, "Ok");
                Application.Current.MainPage = new NavigationPage(new BoasVindasView());

            }
            catch (HttpRequestException)
            {
                await App.Current.MainPage.DisplayAlert("Erro de conex�o", "Verifique sua conex�o com a internet e tente novamente.", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public async Task AutenticarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Email = Email;
                u.SenhaUsuario = SenhaUsuario;

                Usuario uAutenticado = await uService.PostAutenticarUsuarioAsync(u);

                if (uAutenticado != null)
                {
                    
                    string mensagemBemVindo = $"Bem-vindo(a)";
                    string mensagemAcaoSolidaria = $"� A��o Solid�ria!";

                    Preferences.Set("UsuarioId", uAutenticado.IdUsuario);
                    Preferences.Set("UsuarioNome", uAutenticado.Nome);
                    Preferences.Set("UsuarioEmail", uAutenticado.Email);

                    await Application.Current.MainPage.DisplayAlert(mensagemBemVindo, mensagemAcaoSolidaria, "Ok");
                    Application.Current.MainPage = new FeedUsuario();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Informa��o", "Dados incorretos :(", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Informa��o", ex.Message, "Ok");
            }
        }

        public async Task AtualizarUsuario()
        {
            try
            {
                // Obtenha as informa��es do usu�rio autenticado (por exemplo, do armazenamento local)
                int IdUsuario = Preferences.Get("UsuarioId", 0);

                // Verifique se h� um ID de usu�rio v�lido
                if (IdUsuario <= 0)
                {
                    await App.Current.MainPage.DisplayAlert("Erro", "ID de usu�rio inv�lido.", "Ok");
                    return;
                }

                Usuario usuarioAtualizacao = new Usuario
                {
                    IdUsuario = IdUsuario,
                    SenhaUsuario = SenhaUsuario,
                    DescricaoHabilidades = DescricaoHabilidades
                };

                // Chame o m�todo para atualizar o usu�rio
                await uService.AtualizarUsuarioAsync(IdUsuario, usuarioAtualizacao);

                await App.Current.MainPage.DisplayAlert("Sucesso", "Usu�rio atualizado com sucesso.", "Ok");
            }
            catch (HttpRequestException)
            {
                await App.Current.MainPage.DisplayAlert("Erro de conex�o", "Verifique sua conex�o com a internet e tente novamente.", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        private async Task AlterarCadastro()
        {
            try
            {
                // Obtenha as informa��es do usu�rio autenticado (por exemplo, do armazenamento local)
                int idUsuario = Preferences.Get("UsuarioId", 0);

                // Verifique se h� um ID de usu�rio v�lido
                if (idUsuario <= 0)
                {
                    await App.Current.MainPage.DisplayAlert("Erro", "ID de usu�rio inv�lido.", "Ok");
                    return;
                }

                // Redirecione para a p�gina de atualiza��o de dados (substitua `PaginaAtualizacaoDados` pelo nome da sua p�gina)
                //await App.Current.MainPage.Navigation.PushAsync(new AlterarCadastroUsuario(idUsuario));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
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
                await App.Current.MainPage.DisplayAlert("Erro de conex�o", "Verifique sua conex�o com a internet e tente novamente.", "Ok");
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
        private async Task DesconectarUsuario()
        {
            try
            {
                // Adicione aqui a l�gica para limpar os dados de autentica��o, se necess�rio
                Preferences.Remove("UsuarioId");
                Preferences.Remove("UsuarioNome");
                Preferences.Remove("UsuarioEmail");

                // Retorne para o menu principal ou para a p�gina de login, conforme necess�rio
                Application.Current.MainPage = new NavigationPage(new BoasVindasView());

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

    }
}
