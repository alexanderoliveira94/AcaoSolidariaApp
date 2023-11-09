using AcaoSolidariaAppA.ViewModels.Usuarios;

namespace AcaoSolidariaAppA.Views.Usuarios;

public partial class FeedUsuario : ContentPage
{
	public FeedUsuario()
	{
		InitializeComponent();
        BindingContext = new UsuarioViewModel();
    }
}