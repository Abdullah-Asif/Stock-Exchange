using AutoMapper;
using StockExchange.Scraping.BusinessObjects;
using StockExchange.Scraping.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Scraping.Services
{
    public class StockPriceService : IStockPriceService
    {
        private readonly IScrapingUnitOfWork _scrapingUnitOfWork;
        private readonly IMapper _mapper;

        public StockPriceService(IScrapingUnitOfWork scrapingUnitOfWork, IMapper mapper)
        {
            _scrapingUnitOfWork = scrapingUnitOfWork;
            _mapper = mapper;
        }
        public void CreateStockPrice(StockPrice stockPrice)
        {
            if (stockPrice == null)
            {
                throw new InvalidOperationException("Stock Price name can not be null");
            }
  
            _scrapingUnitOfWork.StockPriceRepository.Add(_mapper.Map<Entities.StockPrice>(stockPrice));
            _scrapingUnitOfWork.Save();

        }
    }
}
