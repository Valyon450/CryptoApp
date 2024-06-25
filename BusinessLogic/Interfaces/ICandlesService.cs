using BusinessLogic.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICandlesService
    {
        Task<IEnumerable<CandleDTO>> GetCandles(string coinId, string vsCurrency, int days);
    }
}
