using AcaoSolidariaApp.ViewModels.PublicacaoViewModel;

namespace AcaoSolidariaAppA.Views.Usuarios;

public partial class ParticiparProjetoView : ContentPage
{
    private readonly PublicacaoViewModel _viewModel;
    public ParticiparProjetoView()
	{
		InitializeComponent();
        _viewModel = new PublicacaoViewModel();
        BindingContext = _viewModel;
    }

    private void OnVoltarClicked(object sender, EventArgs e)
    {
        try
        {
            Application.Current.MainPage = new FeedUsuario();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao criar publicação: {ex.Message}");
        }
    }
}