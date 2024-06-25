using BusinessLogic.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRatesService
    {
        Task<IEnumerable<RateDTO>> GetCurrencyRatesAsync();
    }
}
