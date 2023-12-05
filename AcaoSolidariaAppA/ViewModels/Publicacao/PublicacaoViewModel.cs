using System.Collections.ObjectModel;
using System.Windows.Input;
using AcaoSolidariaApp.Models;
using AcaoSolidariaAppA;
using AcaoSolidariaAppA.Services.PublicacaoService;
using AcaoSolidariaAppA.ViewModels;

namespace AcaoSolidariaApp.ViewModels.PublicacaoViewModel
{
    public class PublicacaoViewModel : BaseViewModel
    {
        private readonly PublicacaoService _publicacaoService;

        public ObservableCollection<Publicacao> Publicacoes { get; set; }
        public ICommand CarregarPublicacoesCommand { get; set; }
        public ICommand CandidatarCommand { get; set; }

        public Publicacao NovaPublicacao { get; set; }
        public ICommand CriarPublicacaoCommand { get; set; }

        public PublicacaoViewModel()
        {
            _publicacaoService = new PublicacaoService();
            Publicacoes = new ObservableCollection<Publicacao>();
            NovaPublicacao = new Publicacao();

            CarregarPublicacoesCommand = new Command(async () => await CarregarPublicacoes());
            CandidatarCommand = new Command<int>(async (id) => await Candidatar(id));
            CriarPublicacaoCommand = new Command(async () => await CriarPublicacao());
        }

        public async Task CriarPublicacao()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NovaPublicacao.Conteudo))
                {
                    throw new Exception("O campo Conte�do � obrigat�rio.");
                }

                // Aqui voc� pode adicionar valida��es adicionais conforme necess�rio

                await _publicacaoService.CriarPublicacaoAsync(NovaPublicacao);
                await App.Current.MainPage.DisplayAlert("Sucesso", "Publica��o criada com sucesso!", "Ok");

                // Limpa os campos ou fa�a outras a��es necess�rias ap�s a cria��o
                NovaPublicacao = new Publicacao();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
        public async Task CarregarPublicacoes()
        {
            try
            {
                var publicacoes = await _publicacaoService.ListarPublicacoesAsync();

                Publicacoes.Clear();

                foreach (var publicacao in publicacoes)
                {
                    Publicacoes.Add(publicacao);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        private async Task Candidatar(int idPublicacao)
        {
            try
            {
                await _publicacaoService.CandidatarPublicacaoAsync(idPublicacao);
                await App.Current.MainPage.DisplayAlert("Sucesso", "Voc� se candidatou com sucesso!", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
    }
}
