using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Scraping.Entities
{
    public class StockData
    {
        public string Id { get; set; }
        public string TradingCode { get; set; }
        public string LastTradingPrice { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string ClosePrice { get; set; }
        public string YesterdayClosePrice { get; set; }
        public string Change { get; set; }
        public string Trade { get; set; }
        public string Value { get; set; }
        public string Volume { get; set; }
       

    }
}
