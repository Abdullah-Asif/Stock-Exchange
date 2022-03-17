using StockExchange.Data;
using StockExchange.Scraping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Scraping.Repositories
{
    public interface ICompanyRepository : IRepository<Company, int>
    {
    }
}
