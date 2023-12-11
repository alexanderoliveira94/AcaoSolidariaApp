using AcaoSolidariaApp.ViewModels.PublicacaoViewModel;

namespace AcaoSolidariaAppA.Views.Ong;

public partial class CandidaturasView : ContentPage
{
    private readonly PublicacaoViewModel _viewModel;

    public CandidaturasView()
    {
        InitializeComponent();
        _viewModel = new PublicacaoViewModel();
        BindingContext = _viewModel;
    }

    private void OnVoltarClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new PublicacoesFeed();
    }
}