using System.Collections.ObjectModel;
using System.Windows.Input;
using AcaoSolidariaApp.Models;
using AcaoSolidariaAppA;
using AcaoSolidariaAppA.Services.PublicacaoService;
using AcaoSolidariaAppA.ViewModels;
using AcaoSolidariaAppA.Views.Ong;
using AcaoSolidariaAppA.Views.Usuarios;

namespace AcaoSolidariaApp.ViewModels.PublicacaoViewModel
{
    public class PublicacaoViewModel : BaseViewModel
    {
        private readonly PublicacaoService _publicacaoService;

        public ObservableCollection<Publicacao> Publicacoes { get; set; }
        public ICommand CarregarPublicacoesCommand { get; set; }
        public ICommand CriarPublicacaoCommand { get; set; }
        public ICommand CandidatarPublicacaoCommand { get; set; }
        public ObservableCollection<Candidatura> Candidaturas { get; set; }
        public ICommand CarregarCandidaturasCommand { get; set; }

        private string _titulo = string.Empty;
        public string Titulo
        {
            get => _titulo;
            set
            {
                _titulo = value;
                OnPropertyChanged();
            }
        }

        private string _descricao = string.Empty;
        public string Descricao
        {
            get => _descricao;
            set
            {
                _descricao = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dataInicio = DateTime.Now;
        public DateTime DataInicio
        {
            get => _dataInicio;
            set
            {
                _dataInicio = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dataFim = DateTime.Now;
        public DateTime DataFim
        {
            get => _dataFim;
            set
            {
                _dataFim = value;
                OnPropertyChanged();
            }
        }

        private int _vagasDisponiveis;
        public int VagasDisponiveis
        {
            get => _vagasDisponiveis;
            set
            {
                _vagasDisponiveis = value;
                OnPropertyChanged();
            }
        }

        private string _local = string.Empty;
        public string Local
        {
            get => _local;
            set
            {
                _local = value;
                OnPropertyChanged();
            }
        }

        private int _ongAssociada;
        public int OngAssociada
        {
            get => _ongAssociada;
            set
            {
                _ongAssociada = value;
                OnPropertyChanged();
            }
        }

        private int _idUsuario;
        public int IdUsuario
        {
            get { return _idUsuario; }
            set
            {
                if (_idUsuario != value)
                {
                    _idUsuario = value;
                    OnPropertyChanged(nameof(IdUsuario));
                }
            }
        }

        private int _idPublicacao;
        public int IdPublicacao
        {
            get { return _idPublicacao; }
            set
            {
                if (_idPublicacao != value)
                {
                    _idPublicacao = value;
                    OnPropertyChanged(nameof(IdPublicacao));
                }
            }
        }

        private int _idCandidatura;
        public int IdCandidatura
        {
            get { return _idCandidatura; }
            set
            {
                if (_idCandidatura != value)
                {
                    _idCandidatura = value;
                    OnPropertyChanged(nameof(IdCandidatura));
                }
            }
        }

        private DateTime _dataCandidatura;
        public DateTime DataCandidatura
        {
            get { return _dataCandidatura; }
            set
            {
                if (_dataCandidatura != value)
                {
                    _dataCandidatura = value;
                    OnPropertyChanged(nameof(DataCandidatura));
                }
            }
        }

        public PublicacaoViewModel()
        {
            _publicacaoService = new PublicacaoService();
            Publicacoes = new ObservableCollection<Publicacao>();

            CarregarPublicacoesCommand = new Command(async () => await CarregarPublicacoes());
            CriarPublicacaoCommand = new Command(async () => await CriarPublicacao());
            CandidatarPublicacaoCommand = new Command(async () => await CandidatarPublicacao());
            CarregarCandidaturasCommand = new Command(async () => await CarregarCandidaturas());

            _ = CarregarPublicacoes();
            _ = CarregarCandidaturas();
        }

        public async Task CarregarCandidaturas()
        {
            try
            {
                
                Candidaturas = await _publicacaoService.ListarCandidaturasAsync();
                OnPropertyChanged(nameof(Candidaturas));
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
                Publicacoes = await _publicacaoService.ListarPublicacoes2Async();
                OnPropertyChanged(nameof(Publicacoes));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public async Task CriarPublicacao()
        {
            try
            {
                
                if (string.IsNullOrWhiteSpace(Titulo) || string.IsNullOrWhiteSpace(Descricao))
                {
                    throw new Exception("Os campos Título e Descrição são obrigatórios.");
                }
             
                var novaPublicacao = new Publicacao
                {
                    Titulo = Titulo,
                    Descricao = Descricao,
                    DataInicio = DataInicio,
                    DataFim = DataFim,
                    VagasDisponiveis = VagasDisponiveis,
                    Local = Local,
                    OngAssociada = OngAssociada
                };

                await _publicacaoService.CriarPublicacaoAsync(novaPublicacao);

                Titulo = string.Empty;
                Descricao = string.Empty;
                DataInicio = DateTime.Now;
                DataFim = DateTime.Now;
                VagasDisponiveis = 0;
                Local = string.Empty;
                OngAssociada = 0;

                Application.Current.MainPage = new PublicacoesFeed();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public async Task CandidatarPublicacao()
        {
            try
            {

                await _publicacaoService.CandidatarPublicacaoAsync(IdUsuario, IdPublicacao);

                await App.Current.MainPage.DisplayAlert("Sucesso", "Candidatura realizada com sucesso!", "Ok");

                Application.Current.MainPage = new FeedUsuario();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

    }
}
