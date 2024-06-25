using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class CandlesViewModel : INotifyPropertyChanged
    {
        private readonly ICandlesService _candlesService;
        private PlotModel _plotModel;
        private int _selectedPeriod = 1; // dafault 1 day
        private bool _isNoDataVisible;
        private string _selectedCurrencyId;

        public CandlesViewModel()
        {
            _candlesService = App.Services.GetRequiredService<ICandlesService>();
            PlotModel = new PlotModel();
        }

        public string SelectedCurrencyId
        {
            get => _selectedCurrencyId;
            set
            {
                _selectedCurrencyId = value;
                OnPropertyChanged();
                UpdateTitle();
            }
        }

        public PlotModel PlotModel
        {
            get => _plotModel;
            set
            {
                _plotModel = value;
                UpdateTitle();
                OnPropertyChanged();
            }
        }

        public bool IsNoDataVisible
        {
            get => _isNoDataVisible;
            set
            {
                _isNoDataVisible = value;
                OnPropertyChanged();
            }
        }

        public int SelectedPeriod
        {
            get => _selectedPeriod;
            set
            {
                _selectedPeriod = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadCandles(string currencyId, string quoteId, int period)
        {
            try
            {
                var candles = await _candlesService.GetCandles(currencyId, quoteId, period);
                IsNoDataVisible = candles == null || !candles.Any();
                UpdatePlot(candles);                
            }
            catch (Exception ex)
            {
                IsNoDataVisible = true;
                Console.WriteLine($"Exception in LoadCandles: {ex.Message}");
            }
        }


        public void UpdatePlot(IEnumerable<CandleDTO> candles)
        {
            PlotModel.Series.Clear();
           
            PlotModel.Background = OxyColor.Parse("#1A1A1A"); // Custom dark background color
            PlotModel.TextColor = OxyColors.White;
            PlotModel.PlotAreaBorderColor = OxyColors.Transparent; // Remove border

            if (candles == null || !candles.Any())
            {
                PlotModel.InvalidatePlot(true);
                return;
            }

            var series = new CandleStickSeries
            {
                Color = OxyColors.White,
                IncreasingColor = OxyColors.Green,
                DecreasingColor = OxyColors.Red
            };

            foreach (var candle in candles)
            {
                series.Items.Add(new HighLowItem
                {
                    X = DateTimeAxis.ToDouble(DateTimeOffset.FromUnixTimeMilliseconds(candle.Time).DateTime),
                    Open = Convert.ToDouble(candle.Open),
                    High = Convert.ToDouble(candle.High),
                    Low = Convert.ToDouble(candle.Low),
                    Close = Convert.ToDouble(candle.Close)
                });
            }

            PlotModel.Series.Add(series);

            // X axis (time axis)
            var dateTimeAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "dd/MM/yyyy HH:mm",
                Title = "Time",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                IntervalType = DateTimeIntervalType.Hours,
                FontSize = 10,
                TitleFontSize = 12,
                MajorGridlineColor = OxyColors.Gray,
                MinorGridlineColor = OxyColors.Gray,
                Angle = -70, // Rotate labels
                IsZoomEnabled = false
            };
            PlotModel.Axes.Add(dateTimeAxis);

            // Y axis (price axis)
            var priceAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Price",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                FontSize = 10,
                TitleFontSize = 12,
                MajorGridlineColor = OxyColors.Gray,
                MinorGridlineColor = OxyColors.Gray,
                IsZoomEnabled = false
            };
            PlotModel.Axes.Add(priceAxis);

            PlotModel.InvalidatePlot(true);

            // Set IsNoDataVisible to false as there are valid data points
            IsNoDataVisible = false;
        }

        private void UpdateTitle()
        {
            if (_plotModel != null && !string.IsNullOrEmpty(SelectedCurrencyId))
            {
                _plotModel.Title = $"{SelectedCurrencyId} USD Candlestick Chart";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
