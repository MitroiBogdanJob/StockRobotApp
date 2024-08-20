using System.Collections.Generic;

namespace StockApp.Core
{
    public interface IStockRepository
    {
        List<Stock> GetStocksByExchange(string exchangeCode);
        Stock GetStockByCode(string stockCode);
    }
}
