using Autofac;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StockExchange.Scraping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockExchange.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public  ILifetimeScope AutofacContainer { get; private set; }
        private IScrapingService _scrapingService;

        public Worker(ILogger<Worker> logger, ILifetimeScope lifetimeScope, IScrapingService scrapingService)
        {
            _logger = logger;
            AutofacContainer = lifetimeScope;
            _scrapingService = scrapingService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _scrapingService.SaveStockData();
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}
