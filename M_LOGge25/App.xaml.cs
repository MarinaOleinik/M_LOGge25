using Microsoft.Extensions.DependencyInjection;

namespace M_LOGge25
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //Loome esimese lehe (StartPage) ja määrame selle rakenduse aknaks
            var startPage = new StartPage();
            // Loome NavigationPage, et võimaldada navigeerimist lehtede vahel
            var navigationPage = new NavigationPage(startPage)
            {
                BarBackgroundColor = Colors.LightBlue,
                BarTextColor = Colors.White
            };

            return new Window(navigationPage);
        }
    }
}