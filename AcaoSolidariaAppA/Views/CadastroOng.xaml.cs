namespace AcaoSolidariaAppA.Views;

public partial class CadastroOng : ContentPage
{
	public CadastroOng()
	{
		InitializeComponent();
	}

    private async void RegistrarOngBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroOng());
    }
}