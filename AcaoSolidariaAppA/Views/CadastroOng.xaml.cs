using AcaoSolidariaAppA.ViewModels.Ongs;

namespace AcaoSolidariaAppA.Views;

public partial class CadastroOng : ContentPage
{

    OngViewModel ongViewModel;
    public CadastroOng()
	{
        InitializeComponent();
        ongViewModel = new OngViewModel();
        BindingContext = ongViewModel;
    }

   
}