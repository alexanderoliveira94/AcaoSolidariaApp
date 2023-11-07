using AcaoSolidariaAppA.Views;
using AcaoSolidariaAppA.Views.Usuarios;

namespace AcaoSolidariaAppA
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Routing.RegisterRoute("cadPersonagemView", typeof(FeedUsuario));

            ////string login = Preferences.Get("UsuarioUsername", string.Empty);
            ////lblLogin.Text = $"Login: {login}";
        }
    }
}