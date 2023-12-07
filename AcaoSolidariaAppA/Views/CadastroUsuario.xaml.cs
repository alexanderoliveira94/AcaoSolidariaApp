using AcaoSolidariaAppA.Services.Usuarios;
using AcaoSolidariaAppA.ViewModels.Usuarios;


namespace AcaoSolidariaAppA.Views
{
    public partial class CadastroUsuario : ContentPage
    {
         UsuarioViewModel usuarioViewModel;

        public CadastroUsuario()
        {
            InitializeComponent();
            usuarioViewModel = new UsuarioViewModel();
            BindingContext = usuarioViewModel;
        }

    }
}
