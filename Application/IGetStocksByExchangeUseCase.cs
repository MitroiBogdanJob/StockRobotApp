using StockApp.Core;
using System.Collections.Generic;

namespace StockApp.Application
{
    public interface IGetStocksByExchangeUseCase
    {
        List<Stock> Execute(string exchangeCode);
    }

    public class GetStocksByExchangeUseCase : IGetStocksByExchangeUseCase
    {
        private readonly IStockRepository _stockRepository;

        public GetStocksByExchangeUseCase(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public List<Stock> Execute(string exchangeCode)
        {
            return _stockRepository.GetStocksByExchange(exchangeCode);
        }
    }
}
