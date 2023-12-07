using AcaoSolidariaAppA.ViewModels.Usuarios;


namespace AcaoSolidariaAppA.Views.Usuarios;

public partial class FeedUsuario : FlyoutPage
{
	public FeedUsuario()
	{
        InitializeComponent();
        var usuarioViewModel = new UsuarioViewModel();
        BindingContext = usuarioViewModel;

        // Acesso à instância de PublicacaoViewModel
        var publicacaoViewModel = usuarioViewModel.PublicacaoVM.CarregarPublicacoes;
    }

}