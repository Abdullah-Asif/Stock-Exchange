using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Data
{
    public interface IRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        void Add(TEntity entity);

        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter, string includeProperties = "");


    }
}
