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
                    throw new Exception("Os campos Nome, E-mail e Senha são obrigatórios.");
                }

                if (string.IsNullOrWhiteSpace(DescricaoOng))
                {
                    throw new Exception("O campo Descrição de Habilidades é obrigatório.");
                }

                if (string.IsNullOrWhiteSpace(CNPJOng))
                {
                    throw new Exception("O campo Descrição de Habilidades é obrigatório.");
                }

                if (!IsValidEmail(EmailOng))
                {
                    throw new Exception("O e-mail fornecido não é válido.");
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
                Application.Current.MainPage = new NavigationPage(new BoasVindasView());  // Substituir pela página desejada

            }
            catch (Exception ex)
            {
                // Tratar exceções
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
                    string mensagemAcaoSolidaria = $"à Ação Solidária!";

                    Preferences.Set("OngId", uAutenticado.IdOng?.ToString());
                    Preferences.Set("OngNome", uAutenticado.NomeOng);
                    Preferences.Set("OngEmail", uAutenticado.EmailOng);

                    await Application.Current.MainPage.DisplayAlert(mensagemBemVindo, mensagemAcaoSolidaria, "Ok");
                    Application.Current.MainPage = new FeedUsuario();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Informação", "Dados incorretos :(", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Informação", ex.Message, "Ok");
            }
        }

        //public async Task AtualizarOng()
        //{
        //    try
        //    {
        //        // Obtenha as informações da ONG autenticada (por exemplo, do armazenamento local)
        //        int idOng = Preferences.Get("OngId", 0);

        //        // Verifique se há um ID de ONG válido
        //        if (idOng <= 0)
        //        {
        //            await App.Current.MainPage.DisplayAlert("Erro", "ID de ONG inválido.", "Ok");
        //            return;
        //        }

        //        ONG ongAtualizacao = new ONG
        //        {
        //            IdOng = idOng,
        //            SenhaOng = SenhaOng,
        //            DescricaoOng = DescricaoOng
        //        };

        //        // Chame o método para atualizar a ONG
        //        await ongService.AtualizarOngAsync(idOng, ongAtualizacao);

        //        await App.Current.MainPage.DisplayAlert("Sucesso", "ONG atualizada com sucesso.", "Ok");
        //    }
        //    catch (HttpRequestException)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Erro de conexão", "Verifique sua conexão com a internet e tente novamente.", "Ok");
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
        //        // Obtenha as informações da ONG autenticada (por exemplo, do armazenamento local)
        //        int idOng = Preferences.Get("OngId", 0);

        //        // Verifique se há um ID de ONG válido
        //        if (idOng <= 0)
        //        {
        //            await App.Current.MainPage.DisplayAlert("Erro", "ID de ONG inválido.", "Ok");
        //            return;
        //        }

        //        // Redirecione para a página de atualização de dados (substitua `PaginaAtualizacaoDados` pelo nome da sua página)
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


        private async Task DesconectarOng()
        {
            try
            {
                // Adicione aqui a lógica para limpar os dados de autenticação da ONG, se necessário
                Preferences.Remove("OngId");
                Preferences.Remove("OngNome");
                Preferences.Remove("OngEmail");

                // Retorne para o menu principal ou para a página de login, conforme necessário
                Application.Current.MainPage = new NavigationPage(new BoasVindasView()); // Substituir pela página desejada

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
