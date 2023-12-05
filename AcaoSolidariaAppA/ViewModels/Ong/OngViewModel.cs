using AcaoSolidariaAppA.Services.Ong;
using System.Windows.Input;
using AcaoSolidariaAppA.Models;
using System.Net.Mail;
using AcaoSolidariaAppA.Views;
using AcaoSolidariaAppA.Views.Usuarios;
using AcaoSolidariaApp.ViewModels.PublicacaoViewModel;

namespace AcaoSolidariaAppA.ViewModels.Ongs
{
    public class OngViewModel : BaseViewModel
    {
        
        public OngViewModel()
        {
            ongService = new OngService();
            _publicacaoViewModel = new PublicacaoViewModel();
            InicializarCommands();
        }

        public void InicializarCommands()
        {
            RegistrarOngCommand = new Command(async () => await RegistrarOng());
            AutenticarOngCommand = new Command(async () => await AutenticarOng());
            DirecionarCadastroOngCommand = new Command(async () => await DirecionarParaCadastro());
            DesconectarOngCommand = new Command(async () => await DesconectarOng());
            //AlterarCadastroCommand = new Command(async () => await AlterarCadastro());
            CriarPublicacaoCommand = new Command(async () => await _publicacaoViewModel.CriarPublicacao());
            CarregarPublicacoesCommand = new Command(async () => await _publicacaoViewModel.CarregarPublicacoes());

        }

        private OngService ongService;
        private PublicacaoViewModel _publicacaoViewModel;

        public ICommand RegistrarOngCommand { get; set; }
        public ICommand AutenticarOngCommand { get; set; }
        public ICommand DirecionarCadastroOngCommand { get; set; }
        public ICommand DesconectarOngCommand { get; set; }
        public ICommand CarregarPublicacoesCommand { get; set; }
        public ICommand CriarPublicacaoCommand { get; set; }



        //public ICommand AlterarCadastroCommand { get; set; }

        private string _nomeOng = string.Empty;
        public string NomeOng
        {
            get { return _nomeOng; }
            set
            {
                _nomeOng = value;
                OnPropertyChanged();
            }
        }

        private string _enderecoOng = string.Empty;
        public string EnderecoOng
        {
            get { return _enderecoOng; }
            set
            {
                _enderecoOng = value;
                OnPropertyChanged();
            }
        }

        private string _cnpjOng = string.Empty;
        public string CNPJOng
        {
            get { return _cnpjOng; }
            set
            {
                _cnpjOng = value;
                OnPropertyChanged();
            }
        }

        private string _emailOng = string.Empty;
        public string EmailOng
        {
            get { return _emailOng; }
            set
            {
                _emailOng = value;
                OnPropertyChanged();
            }
        }

        private string _descricaoOng = string.Empty;
        public string DescricaoOng
        {
            get { return _descricaoOng; }
            set
            {
                _descricaoOng = value;
                OnPropertyChanged();
            }
        }

        private string _senhaOng = string.Empty;
        public string SenhaOng
        {
            get { return _senhaOng; }
            set
            {
                _senhaOng = value;
                OnPropertyChanged();
            }
        }

        public async Task RegistrarOng()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NomeOng) || string.IsNullOrWhiteSpace(EmailOng) || string.IsNullOrWhiteSpace(SenhaOng))
                {
                    throw new Exception("Os campos Nome, E-mail e Senha s�o obrigat�rios.");
                }

                if (string.IsNullOrWhiteSpace(DescricaoOng))
                {
                    throw new Exception("O campo Descri��o de Habilidades � obrigat�rio.");
                }

                if (string.IsNullOrWhiteSpace(CNPJOng))
                {
                    throw new Exception("O campo Descri��o de Habilidades � obrigat�rio.");
                }

                if (!IsValidEmail(EmailOng))
                {
                    throw new Exception("O e-mail fornecido n�o � v�lido.");
                }

                ONG ong = new ONG
                {
                    NomeOng = NomeOng,
                    EnderecoOng = EnderecoOng,
                    CNPJOng = CNPJOng,
                    EmailOng = EmailOng,
                    DescricaoOng = DescricaoOng,
                    SenhaOng = SenhaOng
                };

                await ongService.PostRegistrarOngAsync(ong);

                string mensagem = $"Bem-vinda, {ong.NomeOng}!";
                await App.Current.MainPage.DisplayAlert("Sucesso", mensagem, "Ok");
                Application.Current.MainPage = new NavigationPage(new BoasVindasView());  // Substituir pela p�gina desejada

            }
            catch (Exception ex)
            {
                // Tratar exce��es
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public async Task AutenticarOng()
        {
            try
            {
                ONG u = new ONG();
                u.EmailOng = EmailOng;
                u.SenhaOng = SenhaOng;

                ONG uAutenticado = await ongService.PostAutenticarOngAsync(u);

                if (uAutenticado != null)
                {

                    string mensagemBemVindo = $"Bem-vinda";
                    string mensagemAcaoSolidaria = $"� A��o Solid�ria!";

                    Preferences.Set("OngId", uAutenticado.IdOng?.ToString());
                    Preferences.Set("OngNome", uAutenticado.NomeOng);
                    Preferences.Set("OngEmail", uAutenticado.EmailOng);

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

        //public async Task AtualizarOng()
        //{
        //    try
        //    {
        //        // Obtenha as informa��es da ONG autenticada (por exemplo, do armazenamento local)
        //        int idOng = Preferences.Get("OngId", 0);

        //        // Verifique se h� um ID de ONG v�lido
        //        if (idOng <= 0)
        //        {
        //            await App.Current.MainPage.DisplayAlert("Erro", "ID de ONG inv�lido.", "Ok");
        //            return;
        //        }

        //        ONG ongAtualizacao = new ONG
        //        {
        //            IdOng = idOng,
        //            SenhaOng = SenhaOng,
        //            DescricaoOng = DescricaoOng
        //        };

        //        // Chame o m�todo para atualizar a ONG
        //        await ongService.AtualizarOngAsync(idOng, ongAtualizacao);

        //        await App.Current.MainPage.DisplayAlert("Sucesso", "ONG atualizada com sucesso.", "Ok");
        //    }
        //    catch (HttpRequestException)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Erro de conex�o", "Verifique sua conex�o com a internet e tente novamente.", "Ok");
        //    }
        //    catch (Exception ex)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
        //    }
        //}

        //private async Task AlterarCadastro()
        //{
        //    try
        //    {
        //        // Obtenha as informa��es da ONG autenticada (por exemplo, do armazenamento local)
        //        int idOng = Preferences.Get("OngId", 0);

        //        // Verifique se h� um ID de ONG v�lido
        //        if (idOng <= 0)
        //        {
        //            await App.Current.MainPage.DisplayAlert("Erro", "ID de ONG inv�lido.", "Ok");
        //            return;
        //        }

        //        // Redirecione para a p�gina de atualiza��o de dados (substitua `PaginaAtualizacaoDados` pelo nome da sua p�gina)
        //        //await App.Current.MainPage.Navigation.PushAsync(new AlterarCadastroOng(idOng));
        //    }
        //    catch (Exception ex)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
        //    }
        //}


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


        private async Task DesconectarOng()
        {
            try
            {
                // Adicione aqui a l�gica para limpar os dados de autentica��o da ONG, se necess�rio
                Preferences.Remove("OngId");
                Preferences.Remove("OngNome");
                Preferences.Remove("OngEmail");

                // Retorne para o menu principal ou para a p�gina de login, conforme necess�rio
                Application.Current.MainPage = new NavigationPage(new BoasVindasView()); // Substituir pela p�gina desejada

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        private async Task CarregarPublicacoes()
        {
            await _publicacaoViewModel.CarregarPublicacoes();
        }
    }
}
