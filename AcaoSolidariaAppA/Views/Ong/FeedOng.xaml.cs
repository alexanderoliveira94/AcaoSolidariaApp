using AcaoSolidariaAppA.ViewModels.Ongs;

namespace AcaoSolidariaAppA.Views.Ong;

public partial class FeedOng : FlyoutPage
{
	public FeedOng()
	{
        InitializeComponent();
        BindingContext = new OngViewModel();

    }
}