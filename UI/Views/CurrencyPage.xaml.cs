using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using UI.ViewModels;
using BusinessLogic.DTOs;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Views
{
    public sealed partial class CurrencyPage : Page
    {
        private CurrencyViewModel ViewModel => (CurrencyViewModel)DataContext;

        public CurrencyPage()
        {
            this.InitializeComponent();
            DataContext = App.Services.GetRequiredService<CurrencyViewModel>();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            App.AppSettings.CheckTheme(this);
            if (e.Parameter is string currencyId)
            {
                await ViewModel.LoadCurrencyAsync(currencyId);
                await ViewModel.LoadMarketsAsync(currencyId);
            }
        }

        private async void MarketsPanel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is MarketByCurrencyDTO market)
            {
                await ViewModel.OpenMarketUrlAsync(market.ExchangeId);
            }
        }

        private void CandlesPageButton_Click(object sender, EventArgs e)
        {
            if (ViewModel.SelectedCurrency != null)
            {
                Frame.Navigate(typeof(CandlesPage), ViewModel.SelectedCurrency.Id);
            }
        }

    }
}
