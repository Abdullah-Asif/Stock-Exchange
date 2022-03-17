using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EO = StockExchange.Scraping.Entities;
using BO = StockExchange.Scraping.BusinessObjects;
using System.Threading.Tasks;

namespace StockExchange.Scraping.Dependencies
{
    public class ScrapingProfile : Profile
    {
        public ScrapingProfile()
        {
            CreateMap<EO.Company, BO.Company>().ReverseMap();
            CreateMap<EO.StockPrice, BO.StockPrice>().ReverseMap();
        }
    }
}
