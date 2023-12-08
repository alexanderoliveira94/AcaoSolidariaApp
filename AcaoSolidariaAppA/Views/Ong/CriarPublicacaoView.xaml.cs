using AcaoSolidariaApp.ViewModels.PublicacaoViewModel;
using AcaoSolidariaAppA.Views.Ong;

namespace AcaoSolidariaAppA.Views;

public partial class CriarPublicacaoView : ContentPage
{
    private readonly PublicacaoViewModel _viewModel;

    public CriarPublicacaoView()
    {
        InitializeComponent();
        _viewModel = new PublicacaoViewModel();
        BindingContext = _viewModel;
    }

    private void OnVoltarClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new PublicacoesFeed();  // Use PopAsync para voltar para a página anterior
    }
}