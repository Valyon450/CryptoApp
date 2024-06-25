using BusinessLogic.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICurrencyService
    {
        Task<CurrencyDTO> GetCurrencyInfo(string assetId);

        Task<IEnumerable<CurrencyDTO>> GetCurrencies(string limit);

        Task<CurrencyDTO> SearchCurrencyByNameOrSymbol(string query, string limit);

        Task<IEnumerable<MarketByCurrencyDTO>> GetMarketsByCurrency(string assetId, string limit);
    }
}
