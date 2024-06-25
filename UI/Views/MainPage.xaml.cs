using BusinessLogic.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;
using UI.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UI.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => (MainViewModel)DataContext;
        private readonly DispatcherTimer _timer;

        public MainPage()
        {
            this.InitializeComponent();
            DataContext = App.Services.GetRequiredService<MainViewModel>();

            // Start the timer to update data every 5 seconds
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(5)
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            App.AppSettings.CheckTheme(this);
        }

        private async void Timer_Tick(object sender, object e)
        {
            await ViewModel.LoadDataAsync();
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string query = SearchBox.Text.Trim();
            if (!string.IsNullOrEmpty(query))
            {
                await ViewModel.SearchCurrencyAsync(query);
            }
        }

        private void CurrenciesPanel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is CurrencyDTO selectedCurrency)
            {
                this.Frame.Navigate(typeof(CurrencyPage), selectedCurrency.Id);
            }
        }

        private void RefreshRateComboBox_RefreshRateChanged(object sender, int seconds)
        {
            _timer.Interval = TimeSpan.FromSeconds(seconds);
        }
    }
}
