using StockExchange.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Scraping.BusinessObjects
{
    public class Company
    {
        public int Id { get; set; }
        public string TradeCode { get; set; }
    }
}
