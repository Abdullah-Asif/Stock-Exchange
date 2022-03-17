using Microsoft.EntityFrameworkCore;
using StockExchange.Scraping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Scraping.Contexts
{
    public class ScrapingContext : DbContext, IScrapingContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssmeblyName;
        public ScrapingContext(string connectionString, string migrationAssemblyName)            
        {
            _connectionString = connectionString;
            _migrationAssmeblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(_connectionString,
                     m => m.MigrationsAssembly(_migrationAssmeblyName));
            }
            base.OnConfiguring(dbContextOptionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockPrice>()
                .HasOne(st => st.Company)
                .WithMany(c => c.StockPrices)
                .HasForeignKey(st => st.CompanyId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }
    }
}
