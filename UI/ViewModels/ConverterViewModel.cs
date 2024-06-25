using BusinessLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace UI.ViewModels
{
    public class ConverterViewModel : INotifyPropertyChanged
    {
        private readonly IRatesService _ratesService;
        private decimal _amount;
        private decimal _convertedAmount;
        private string _fromCurrency;
        private string _toCurrency;
        private ObservableCollection<string> _currencies;
        private Dictionary<string, decimal> _currencyRates;

        public ConverterViewModel()
        {
            _ratesService = App.Services.GetRequiredService<IRatesService>();
            LoadCurrencyRates();
        }

        public string AmountInput { get; set; }

        public decimal Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged();
                ConvertCurrency();
            }
        }

        public decimal ConvertedAmount
        {
            get => _convertedAmount;
            set
            {
                _convertedAmount = value;
                OnPropertyChanged();
            }
        }

        public string FromCurrency
        {
            get => _fromCurrency;
            set
            {
                _fromCurrency = value;
                OnPropertyChanged();
                ConvertCurrency();
            }
        }

        public string ToCurrency
        {
            get => _toCurrency;
            set
            {
                _toCurrency = value;
                OnPropertyChanged();
                ConvertCurrency();
            }
        }

        public ObservableCollection<string> Currencies
        {
            get => _currencies;
            set
            {
                _currencies = value;
                OnPropertyChanged();
            }
        }

        private async void LoadCurrencyRates()
        {
            var rates = await _ratesService.GetCurrencyRatesAsync();
            _currencyRates = rates.ToDictionary(c => c.Id, c => c.RateUsd);

            Currencies = new ObservableCollection<string>(_currencyRates.Keys);
        }

        private void ConvertCurrency()
        {
            if (string.IsNullOrEmpty(FromCurrency) || string.IsNullOrEmpty(ToCurrency) || Amount <= 0)
                return;

            if (_currencyRates.ContainsKey(FromCurrency) && _currencyRates.ContainsKey(ToCurrency))
            {
                var fromRate = _currencyRates[FromCurrency];
                var toRate = _currencyRates[ToCurrency];
                ConvertedAmount = Amount / toRate * fromRate;
            }
        }

        public void UpdateAmountFromInput()
        {
            if (decimal.TryParse(AmountInput, out decimal amount))
            {
                Amount = amount;
            }
            else
            {
                Amount = 0;
                ConvertedAmount = 0;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
