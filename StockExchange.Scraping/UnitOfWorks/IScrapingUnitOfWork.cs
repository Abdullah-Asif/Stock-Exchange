using StockExchange.Data;
using StockExchange.Scraping.Repositories;

namespace StockExchange.Scraping.UnitOfWorks
{
    public interface IScrapingUnitOfWork : IUnitOfWork
    {
        public ICompanyRepository CompanyRepository { get; set; }
        public IStockPriceRepository StockPriceRepository { get; set; }
    }
}