using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ICurrencyService _currencyService;
        private ObservableCollection<CurrencyDTO> _currencies;

        public MainViewModel()
        {
            _currencyService = App.Services.GetRequiredService<ICurrencyService>();
            _ = LoadDataAsync();
        }

        public ObservableCollection<CurrencyDTO> Currencies
        {
            get => _currencies;
            set
            {
                _currencies = value;
                OnPropertyChanged();
            }
        }        

        public async Task LoadDataAsync()
        {
            var currencies = await _currencyService.GetCurrencies("20");
            Currencies = new ObservableCollection<CurrencyDTO>(currencies);
        }

        public async Task SearchCurrencyAsync(string query)
        {
            var currency = await _currencyService.SearchCurrencyByNameOrSymbol(query, "10");
            if (currency != null)
            {
                Currencies.Clear();
                Currencies.Add(currency);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
