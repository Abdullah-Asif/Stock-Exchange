using StockExchange.Scraping.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Scraping.Services
{
    public interface ICompanyService
    {
        void CreateCompany(Company companie);

        Company GetByTradeId(string tradeCode);
    }
}
