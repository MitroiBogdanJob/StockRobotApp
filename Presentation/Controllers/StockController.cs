using Microsoft.AspNetCore.Mvc;
using StockApp.Application;
using StockApp.Core;
using System.Collections.Generic;

namespace StockApp.WebUI.Controllers
{
    public class StockController : Controller
    {
        private readonly IGetStocksByExchangeUseCase _getStocksByExchangeUseCase;
        private readonly IGetStockDetailsUseCase _getStockDetailsUseCase;

        public StockController(IGetStocksByExchangeUseCase getStocksByExchangeUseCase, IGetStockDetailsUseCase getStockDetailsUseCase)
        {
            _getStocksByExchangeUseCase = getStocksByExchangeUseCase;
            _getStockDetailsUseCase = getStockDetailsUseCase;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StockMenu(string exchangeCode)
        {
            List<Stock> stocks = _getStocksByExchangeUseCase.Execute(exchangeCode);
            return View(stocks);
        }

        public IActionResult StockDetails(string stockCode)
        {
            Stock stock = _getStockDetailsUseCase.Execute(stockCode);
            return View(stock);
        }
    }
}
