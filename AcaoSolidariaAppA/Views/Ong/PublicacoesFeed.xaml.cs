using AcaoSolidariaApp.ViewModels.PublicacaoViewModel;
using AcaoSolidariaAppA.ViewModels.Ongs;

namespace AcaoSolidariaAppA.Views.Ong;

public partial class PublicacoesFeed : ContentPage
{
    private readonly PublicacaoViewModel _viewModel;

    public PublicacoesFeed()
	{
		InitializeComponent();

        _viewModel = new PublicacaoViewModel();
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = _viewModel.CarregarPublicacoes();
    }
}