using AcaoSolidariaApp.ViewModels.PublicacaoViewModel;
using AcaoSolidariaAppA.ViewModels.Usuarios;




namespace AcaoSolidariaAppA.Views.Usuarios;

public partial class FeedUsuario : FlyoutPage
{
    private readonly PublicacaoViewModel _viewModel;
    private readonly UsuarioViewModel _usuarioViewModel;
    public FeedUsuario()
    {
        InitializeComponent();
        _usuarioViewModel = new UsuarioViewModel();
        _viewModel = new PublicacaoViewModel();
        BindingContext = _usuarioViewModel;
        listView.BindingContext = _viewModel;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = _viewModel.CarregarPublicacoes();
    }
}

