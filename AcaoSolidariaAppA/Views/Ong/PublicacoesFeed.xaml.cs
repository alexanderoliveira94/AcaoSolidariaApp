using AcaoSolidariaApp.ViewModels.PublicacaoViewModel;
using AcaoSolidariaAppA.ViewModels.Ongs;

namespace AcaoSolidariaAppA.Views.Ong;

public partial class PublicacoesFeed : FlyoutPage
{
    private readonly PublicacaoViewModel _viewModel;
    private readonly OngViewModel _ongViewModel;

    public PublicacoesFeed()
	{
		InitializeComponent();
        _ongViewModel = new OngViewModel();
        _viewModel = new PublicacaoViewModel();
        BindingContext = _ongViewModel;
        listView.BindingContext = _viewModel;
    }
     
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = _viewModel.CarregarPublicacoes();
    }

    private void OnCriarPublicacaoClicked(object sender, EventArgs e)
    {
        try
        {
            Application.Current.MainPage = new CriarPublicacaoView();
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao criar publicação: {ex.Message}");
        }
    }

    private void CandidaduturasClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new CandidaturasView();
    }
}