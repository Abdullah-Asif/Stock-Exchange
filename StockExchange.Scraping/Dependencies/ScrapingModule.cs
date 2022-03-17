using Autofac;
using StockExchange.Scraping.Contexts;
using StockExchange.Scraping.Repositories;
using StockExchange.Scraping.Services;
using StockExchange.Scraping.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Scraping.Dependencies
{
    public class ScrapingModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ScrapingModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ScrapingContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ScrapingContext>().As<IScrapingContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StockPriceRepository>().As<IStockPriceRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ScrapingUnitOfWork>().As<IScrapingUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ScrapingService>().As<IScrapingService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CompanyService>().As<ICompanyService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<StockPriceService>().As<IStockPriceService>()
               .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
