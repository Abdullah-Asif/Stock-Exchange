using System;

namespace StockExchange.Data
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
