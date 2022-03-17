using StockExchange.Scraping.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Scraping.Services
{
    public interface IStockPriceService
    {
        void CreateStockPrice(StockPrice stockPrice);
    }
}
