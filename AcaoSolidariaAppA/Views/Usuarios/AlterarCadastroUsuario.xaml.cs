using AcaoSolidariaAppA.Models;
using AcaoSolidariaAppA.ViewModels.Usuarios;

namespace AcaoSolidariaAppA.Views.Usuarios;

public partial class AlterarCadastroUsuario : ContentPage
{
	public AlterarCadastroUsuario()  
	{
		InitializeComponent();
        BindingContext = new UsuarioViewModel();
    }
}