using System;
using StockExchange.Scraping.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Scraping.Services
{
    public interface IScrapingService
    {
        void SaveStockData();
        List<StockData> GetStockData();

        void Display();
    }
}
