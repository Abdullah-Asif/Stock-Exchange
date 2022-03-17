using AutoMapper;
using StockExchange.Scraping.BusinessObjects;
using StockExchange.Scraping.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Scraping.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IScrapingUnitOfWork _scrapingUnitOfWork;
        private readonly IMapper _mapper;
        public int Count = 0;

        public CompanyService(IScrapingUnitOfWork scrapingUnitOfWork, IMapper mapper)
        {
            _scrapingUnitOfWork = scrapingUnitOfWork;
            _mapper = mapper;
        }
        public void CreateCompany(Company company)
        {
            if (company == null)
            {
                throw new InvalidOperationException("Company name can not be null");
            }
          
            _scrapingUnitOfWork.CompanyRepository.Add(_mapper.Map<Entities.Company>(company));
            _scrapingUnitOfWork.Save();
            Count++;
            using StreamWriter file = new(@"D:\Code\AspNET\.Net\ASP.NET\StockExchange\Data.txt", append: true);
            file.WriteLine(Count.ToString());

        }

        public Company GetByTradeId(string tradeCode)
        {
            if (tradeCode == null)
            {
                throw new InvalidOperationException("Tade Code can not be null");
            }

            return _mapper.Map<Company>(_scrapingUnitOfWork.CompanyRepository
                .Get(x => x.TradeCode == tradeCode, string.Empty)
                .FirstOrDefault());
        }
    }
}
