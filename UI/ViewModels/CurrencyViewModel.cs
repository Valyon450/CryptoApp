using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Windows.System;

namespace UI.ViewModels
{
    public class CurrencyViewModel : INotifyPropertyChanged
    {        
        private readonly ICurrencyService _currencyService;
        private readonly IMarketService _marketService;
        private CurrencyDTO _selectedCurrency;
        private ObservableCollection<MarketByCurrencyDTO> _markets;        

        public CurrencyViewModel()
        {
            _currencyService = App.Services.GetRequiredService<ICurrencyService>();
            _marketService = App.Services.GetRequiredService<IMarketService>();
        }

        public CurrencyDTO SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                if (_selectedCurrency != value)
                {
                    _selectedCurrency = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<MarketByCurrencyDTO> Markets
        {
            get => _markets;
            set
            {
                _markets = value;
                OnPropertyChanged();
            }
        }        

        public async Task LoadCurrencyAsync(string currencyId)
        {
            SelectedCurrency = await _currencyService.GetCurrencyInfo(currencyId);
        }

        public async Task LoadMarketsAsync(string currencyId)
        {
            var markets = await _currencyService.GetMarketsByCurrency(currencyId, "20");
            Markets = new ObservableCollection<MarketByCurrencyDTO>(markets);
        }

        public async Task OpenMarketUrlAsync(string exchangeId)
        {
            try
            {
                var marketDetails = await _marketService.GetMarketInfo(exchangeId);
                if(marketDetails != null && marketDetails.URL != null)
                {
                    var uri = new Uri(marketDetails.URL);
                    await Launcher.LaunchUriAsync(uri);
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in LoadCandles: {ex.Message}");
                return;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
