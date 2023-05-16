using Caliburn.Micro;
using DCTest.ViewModels;
using System.Windows;

namespace DCTest {
    public class Bootstrapper : BootstrapperBase {
        public Bootstrapper () {
            Initialize ();
        }

        protected override async void OnStartup (object sender, StartupEventArgs e) {
            await DisplayRootViewForAsync<MainViewModel> ();
        }
    }
}
