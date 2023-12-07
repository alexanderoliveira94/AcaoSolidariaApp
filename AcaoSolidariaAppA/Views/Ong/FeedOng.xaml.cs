using AcaoSolidariaApp.ViewModels.PublicacaoViewModel;
using AcaoSolidariaAppA.ViewModels.Ongs;

namespace AcaoSolidariaAppA.Views.Ong;

public partial class FeedOng : FlyoutPage
{
    private readonly PublicacaoViewModel _viewModel;
    private readonly OngViewModel _ongViewModel;

    public FeedOng()
	{
        InitializeComponent();
        
        _viewModel = new PublicacaoViewModel();

        _ongViewModel = new OngViewModel();

        BindingContext = _viewModel;
    }   
    private async void CriarPublicacaoClicked(object sender, EventArgs e)
    {
        // Execute a lógica para criar a nova publicação no ViewModel
        await _viewModel.CriarPublicacao();
    }
}