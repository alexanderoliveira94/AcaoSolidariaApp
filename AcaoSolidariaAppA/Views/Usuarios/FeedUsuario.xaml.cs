using AcaoSolidariaAppA.ViewModels.Usuarios;

namespace AcaoSolidariaAppA.Views.Usuarios;

public partial class FeedUsuario : FlyoutPage
{
	public FeedUsuario()
	{
		InitializeComponent();
        BindingContext = new UsuarioViewModel();
    }
}