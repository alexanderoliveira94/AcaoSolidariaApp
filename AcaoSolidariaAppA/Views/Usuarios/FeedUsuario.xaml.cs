using AcaoSolidariaAppA.ViewModels.Usuarios;


namespace AcaoSolidariaAppA.Views.Usuarios;

public partial class FeedUsuario : FlyoutPage
{
	public FeedUsuario()
	{
        InitializeComponent();
        var usuarioViewModel = new UsuarioViewModel();
        BindingContext = usuarioViewModel;

        // Acesso � inst�ncia de PublicacaoViewModel
        var publicacaoViewModel = usuarioViewModel.PublicacaoVM.CarregarPublicacoes;
    }

}