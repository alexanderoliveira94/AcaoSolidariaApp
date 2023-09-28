namespace AcaoSolidariaAppA.Views;

public partial class BoasVindasView : ContentPage
{
	public BoasVindasView()
	{
		InitializeComponent();
	}

    private async void ComecarBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Page());
    }
}