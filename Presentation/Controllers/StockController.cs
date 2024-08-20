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
            ViewBag.Message = "Hello! Welcome to LSEG chatbot. Please select a Stock Exchange.";
            return View();
        }

        public IActionResult StockMenu(string exchangeCode)
        {
            ViewBag.Message = "Please select a stock.";
            List<Stock> stocks = _getStocksByExchangeUseCase.Execute(exchangeCode);
            return View(stocks);
        }

        public IActionResult StockDetails(string stockCode)
        {
            ViewBag.Message = "Here is the stock price.";
            Stock stock = _getStockDetailsUseCase.Execute(stockCode);
            return View(stock);
        }
    }
}
