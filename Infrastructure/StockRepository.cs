using Newtonsoft.Json.Linq;
using StockApp.Core;
using Newtonsoft.Json;
using StockApp.Core;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace StockApp.Infrastructure
{
    public class StockRepository : IStockRepository
    {
        private readonly string _filePath;
        private readonly ILogger<StockRepository> _logger;

        public StockRepository(string filePath, ILogger<StockRepository> logger)
        {
            _filePath = filePath;
            _logger = logger;

            if (!File.Exists(_filePath))
            {
                _logger.LogError($"File not found: {_filePath}");
                throw new FileNotFoundException($"The required file '{_filePath}' was not found.");
            }
        }

        public List<Stock> GetStocksByExchange(string exchangeCode)
        {
            try
            {
                var stocks = new List<Stock>();
                var json = File.ReadAllText(_filePath);
                var data = JArray.Parse(json);

                foreach (var exchange in data)
                {
                    if (exchange["code"].ToString() == exchangeCode)
                    {
                        foreach (var stock in exchange["topStocks"])
                        {
                            stocks.Add(new Stock
                            {
                                Code = stock["code"].ToString(),
                                StockName = stock["stockName"].ToString(),
                                Price = decimal.Parse(stock["price"].ToString())
                            });
                        }
                    }
                }

                return stocks;
            }
            catch (JsonReaderException ex)
            {
                _logger.LogError(ex, "Error reading the JSON file: Invalid format.");
                throw new InvalidDataException("The JSON file contains invalid data.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unknown error occurred while reading the file.");
                throw new ApplicationException("An error occurred while processing data from the JSON file.", ex);
            }
        }

        public Stock GetStockByCode(string stockCode)
        {
            try
            {
                var json = File.ReadAllText(_filePath);
                var data = JArray.Parse(json);

                foreach (var exchange in data)
                {
                    foreach (var stock in exchange["topStocks"])
                    {
                        if (stock["code"].ToString() == stockCode)
                        {
                            return new Stock
                            {
                                Code = stock["code"].ToString(),
                                StockName = stock["stockName"].ToString(),
                                Price = decimal.Parse(stock["price"].ToString())
                            };
                        }
                    }
                }

                return null;
            }
            catch (JsonReaderException ex)
            {
                _logger.LogError(ex, "Error reading the JSON file: Invalid format.");
                throw new InvalidDataException("The JSON file contains invalid data.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unknown error occurred while reading the file.");
                throw new ApplicationException("An error occurred while processing data from the JSON file.", ex);
            }
        }
    }
}