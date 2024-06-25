using BusinessLogic.DTOs;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IMarketService
    {
        Task<MarketDTO> GetMarketInfo(string exchangeId);
    }
}
