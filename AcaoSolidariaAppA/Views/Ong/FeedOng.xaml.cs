using AcaoSolidariaApp.ViewModels.PublicacaoViewModel;
using AcaoSolidariaAppA.ViewModels.Ongs;

namespace AcaoSolidariaAppA.Views.Ong;

public partial class FeedOng : FlyoutPage
{
    private readonly PublicacaoViewModel _viewModel;
<<<<<<< HEAD
    private readonly OngViewModel _ongViewModel;
=======
>>>>>>> d1e7ccd178de182fbe2ca7852b4ce1dba323769e

    public FeedOng()
	{
        InitializeComponent();
<<<<<<< HEAD
        
        _viewModel = new PublicacaoViewModel();

        _ongViewModel = new OngViewModel();

        BindingContext = _viewModel;
    }   
=======
        _viewModel = new PublicacaoViewModel();
        BindingContext = _viewModel;
    }
>>>>>>> d1e7ccd178de182fbe2ca7852b4ce1dba323769e
    private async void CriarPublicacaoClicked(object sender, EventArgs e)
    {
        // Execute a lógica para criar a nova publicação no ViewModel
        await _viewModel.CriarPublicacao();
    }
}