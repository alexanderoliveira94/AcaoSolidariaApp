namespace AcaoSolidariaAppA.Views;

public partial class EscolhaOngVoluntario : ContentPage
{
	public EscolhaOngVoluntario()
	{
		InitializeComponent();
	}

    private async void OngBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroOng());
    }

    private async void VoluntarioBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroUsuario());
    }
}