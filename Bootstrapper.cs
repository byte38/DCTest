using Caliburn.Micro;
using DCTest.Extensions;
using DCTest.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DCTest {
    public class Bootstrapper : BootstrapperBase {
        private readonly SimpleContainer _container = new SimpleContainer ();

        public static IHost ApplicationHost { get; private set; }

        public Bootstrapper () {
            ApplicationHost = Host.CreateDefaultBuilder ()
                .ConfigureServices ((hostContext, services) => {
                    services.AddCustomServices ();

                    services.AddSingleton<IWindowManager, WindowManager> ();
                    services.AddSingleton<MainViewModel> ();
                })
                .Build ();

            Initialize ();
        }

        protected override async void OnStartup (object sender, StartupEventArgs e) {
            await ApplicationHost.StartAsync ();

            await DisplayRootViewForAsync<MainViewModel> ();
        }

        protected override object GetInstance (Type serviceType, string key) {
            return ApplicationHost.Services.GetService (serviceType);
        }

        protected override IEnumerable<object> GetAllInstances (Type serviceType) {
            return _container.GetAllInstances (serviceType);
        }

        protected override void BuildUp (object instance) {
            _container.BuildUp (instance);
        }

        protected override async void OnExit (object sender, EventArgs e) {
            await ApplicationHost.StopAsync ();
        }
    }
}
