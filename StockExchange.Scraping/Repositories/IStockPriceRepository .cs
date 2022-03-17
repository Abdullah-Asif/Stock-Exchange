using StockExchange.Scraping.Entities;
using StockExchange.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Scraping.Repositories
{
    public interface IStockPriceRepository : IRepository<StockPrice, int>
    {
    }
}
