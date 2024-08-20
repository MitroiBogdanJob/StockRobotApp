using StockApp.Core;

namespace StockApp.Application
{
    public interface IGetStockDetailsUseCase
    {
        Stock Execute(string stockCode);
    }

    public class GetStockDetailsUseCase : IGetStockDetailsUseCase
    {
        private readonly IStockRepository _stockRepository;

        public GetStockDetailsUseCase(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public Stock Execute(string stockCode)
        {
            return _stockRepository.GetStockByCode(stockCode);
        }
    }
}
