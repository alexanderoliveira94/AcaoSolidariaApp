namespace AcaoSolidariaAppA.Views;

public partial class CadastroUsuario : ContentPage
{
	public CadastroUsuario()
	{
		InitializeComponent();
	}
    private async void RegistrarUsuarioBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroOng());
    }
}