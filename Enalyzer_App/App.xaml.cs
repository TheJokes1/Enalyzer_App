using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enalyzer_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

        }

        protected override void OnStart()
        {
            var service = new RestService();
            var result = service.RefreshDataAsync();

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
