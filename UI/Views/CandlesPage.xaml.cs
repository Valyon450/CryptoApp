using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UI.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UI.Views
{
    public sealed partial class CandlesPage : Page
    {
        private CandlesViewModel ViewModel => (CandlesViewModel)DataContext;

        public CandlesPage()
        {
            this.InitializeComponent();
            DataContext = App.Services.GetRequiredService<CandlesViewModel>();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            App.AppSettings.CheckTheme(this);
            if (e.Parameter is string currencyId && e.NavigationMode == NavigationMode.New)
            {
                ViewModel.SelectedCurrencyId = currencyId;
                await ViewModel.LoadCandles(currencyId, "usd", ViewModel.SelectedPeriod);
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        private async Task UpdateCandles()
        {
            await ViewModel.LoadCandles(ViewModel.SelectedCurrencyId, "usd", ViewModel.SelectedPeriod);
        }

        private void PeriodComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PeriodComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                if (int.TryParse(selectedItem.Tag.ToString(), out int days))
                {
                    ViewModel.SelectedPeriod = days;
                    _ = UpdateCandles();
                }
            }
        }
    }
}
