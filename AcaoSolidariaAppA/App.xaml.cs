using AcaoSolidariaAppA.Views;

namespace AcaoSolidariaAppA
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new BoasVindasView());
        }
    }
}