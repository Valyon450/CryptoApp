using Microsoft.Extensions.DependencyInjection;
using System;
using UI.DI;
using UI.Views;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UI
{
    sealed partial class App : Application
    {
        public static AppSettings AppSettings { get; } = new AppSettings();
        private IServiceProvider _serviceProvider;

        public static IServiceProvider Services => ((App)Current)._serviceProvider
            ?? throw new InvalidOperationException("The service provider is not initialized");

        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            _serviceProvider = ConfigureServices();
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.ConfigureDependency();
            return services.BuildServiceProvider(true);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            AppSettings.AppTheme = ElementTheme.Light;
            AppSettings.AppLanguage = "en-US";


            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                Window.Current.Activate();
            }
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save the application state and stop all background operations
            deferral.Complete();
        }
    }
}
