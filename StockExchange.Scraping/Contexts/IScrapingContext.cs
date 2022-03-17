using Microsoft.EntityFrameworkCore;
using StockExchange.Scraping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Scraping.Contexts
{
    public interface IScrapingContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }

    }
}
