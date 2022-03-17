using StockExchange.Data;
using StockExchange.Scraping.Contexts;
using StockExchange.Scraping.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Scraping.UnitOfWorks
{
    public class ScrapingUnitOfWork : UnitOfWork, IScrapingUnitOfWork
    {
        public ICompanyRepository CompanyRepository { get; set; }
        public IStockPriceRepository StockPriceRepository { get; set; }
        public ScrapingUnitOfWork(ICompanyRepository companyRepository,
            IStockPriceRepository stockPriceRepository, ScrapingContext context) : base(context)
        {
            CompanyRepository = companyRepository;
            StockPriceRepository = stockPriceRepository;
        }
 
    }
}
