using Caliburn.Micro;
using DCTest.ViewModels;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace DCTest {
    public class Bootstrapper : BootstrapperBase {
        public static IHost ApplicationHost { get; private set; }

        public Bootstrapper () {
            ApplicationHost = Host.CreateDefaultBuilder ()
                .ConfigureServices ((hostContext, services) => {

                })
                .Build ();

            Initialize ();
        }

        protected override async void OnStartup (object sender, StartupEventArgs e) {
            await ApplicationHost.StartAsync ();

            await DisplayRootViewForAsync<MainViewModel> ();
        }

        protected override async void OnExit (object sender, EventArgs e) {
            await ApplicationHost.StopAsync ();
        }
    }
}
