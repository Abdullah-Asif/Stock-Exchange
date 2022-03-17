using StockExchange.Data;
using StockExchange.Scraping.Contexts;
using StockExchange.Scraping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Scraping.Repositories
{
    public class StockPriceRepository : Repository<StockPrice, int>, IStockPriceRepository
    {
        public StockPriceRepository(IScrapingContext context) : base((ScrapingContext)(context))
        {

        }
    }
}
