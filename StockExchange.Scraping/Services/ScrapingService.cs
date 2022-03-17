using AutoMapper;
using HtmlAgilityPack;
using StockExchange.Scraping.Entities;
using BO = StockExchange.Scraping.BusinessObjects;
using StockExchange.Scraping.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Scraping.Services
{
    public class ScrapingService : IScrapingService
    {
        private readonly HtmlWeb _web;
        private readonly string _html;
        private readonly HtmlDocument _htmlDoc;
        private readonly HtmlNode[] _nodes;
        private readonly ICompanyService _companyService;
        private readonly IStockPriceService _stockPriceService;
        private string _currentStatus;
        public ScrapingService(ICompanyService companyService, IStockPriceService stockPriceService)
        {
            _companyService = companyService;
            _stockPriceService = stockPriceService;
            _web = new HtmlWeb();
            _html = @"https://www.dsebd.org/latest_share_price_scroll_by_value.php";
            _htmlDoc = _web.Load(_html);

            _currentStatus = _htmlDoc.DocumentNode
                    .SelectSingleNode("//div[@class='HeaderTop']/span[@class='time']/span[@class='green']")
                    .InnerText;

            _nodes = _htmlDoc.DocumentNode
               .SelectNodes("//table[@class='table table-bordered background-white shares-table fixedHeader']").ToArray();
        }
        public void SaveStockData()
        {
            if (_currentStatus.Equals("Closed"))
            {
                foreach (var item in GetStockData())
                {
                    BO.Company company = new BO.Company()
                    {
                        Id = int.Parse(item.Id),
                        TradeCode = item.TradingCode
                    };

                    BO.StockPrice stockPrice = new BO.StockPrice()
                    {
                        Id = company.Id,
                        LastTradingPrice = item.LastTradingPrice,
                        High = item.High,
                        Low = item.Low,
                        ClosePrice = item.ClosePrice,
                        YesterdayClosePrice = item.YesterdayClosePrice,
                        Change = item.Change,
                        Trade = item.Trade,
                        Value = item.Value,
                        Volume = item.Volume,
                        CompanyId = company.Id,
                    };

                    if (_companyService.GetByTradeId(item.TradingCode) == null)
                    {
                        _companyService.CreateCompany(company);
                        //_stockPriceService.CreateStockPrice(stockPrice);
                    }
                    //else
                    //{
                    //    _stockPriceService.CreateStockPrice(stockPrice);
                    //}


                }
            }
        }

        public List<StockData> GetStockData()
        {
            var stockDataList = new List<StockData>();
            foreach (var item in _nodes)
            {
                var rawData = item.SelectNodes(".//tr/td");
                for (int i = 0; i < rawData.Count; i += 11)
                {
                    var data = new StockData();
                    data.Id = rawData[i].InnerText.Trim();
                    data.TradingCode = rawData[i + 1].InnerText.Trim();
                    data.LastTradingPrice = rawData[i + 2].InnerText.Trim();
                    data.High = rawData[i + 3].InnerText.Trim();
                    data.Low = rawData[i + 4].InnerText.Trim();
                    data.ClosePrice = rawData[i + 5].InnerText.Trim();
                    data.YesterdayClosePrice = rawData[i + 6].InnerText.Trim();
                    data.Change = rawData[i + 7].InnerText.Trim();
                    data.Trade = rawData[i + 8].InnerText.Trim();
                    data.Value = rawData[i + 9].InnerText.Trim();
                    data.Volume = rawData[i + 10].InnerText.Trim();

                    stockDataList.Add(data);
                }             
            }
            return stockDataList;
        }

        public void Display()
        {
            foreach (var item in GetStockData())
            {
                Console.WriteLine(item.TradingCode);
            }
        }
    }
}
