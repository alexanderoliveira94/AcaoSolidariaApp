using AcaoSolidariaApp.ViewModels.PublicacaoViewModel;
using AcaoSolidariaAppA.ViewModels.Ongs;

namespace AcaoSolidariaAppA.Views.Ong;

public partial class FeedOng : FlyoutPage
{
    private readonly OngViewModel _viewModel;

    public FeedOng()
    {
        InitializeComponent();
        _viewModel = new OngViewModel();
        BindingContext = _viewModel;
    }
    private async void CriarPublicacaoClicked(object sender, EventArgs e)
    {
        // Execute a lógica para criar a nova publicação no ViewModel
        //await _viewModel.CriarPublicacao();
    }
}