using BusinessLogic.Interfaces;
using BusinessLogic.Services.CoinCapApi;
using BusinessLogic.Services.CoinGeckoApi;
using Microsoft.Extensions.DependencyInjection;
using UI.ViewModels;

namespace UI.DI
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection ConfigureDependency(this IServiceCollection services)
        {
            // Services
            services.AddSingleton<ICurrencyService, CurrencyService>();
            services.AddSingleton<IMarketService, MarketService>();
            services.AddSingleton<IRatesService, RatesService>();
            services.AddSingleton<ICandlesService, CandlesService>();

            // ViewModels
            services.AddSingleton<CandlesViewModel>();
            services.AddSingleton<ConverterViewModel>();
            services.AddSingleton<CurrencyViewModel>();
            services.AddSingleton<MainViewModel>();

            return services;
        }
    }
}