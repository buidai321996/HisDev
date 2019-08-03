using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Datas
{
    public class Queryable<TEntity> : IQueryable<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        public Queryable(DbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
            
        }
        
        public Type ElementType => ((IQueryable)_dbSet).ElementType;

        public Expression Expression => ((IQueryable)_dbSet).Expression;

        public IQueryProvider Provider => ((IQueryable)_dbSet).Provider;

        public IEnumerator<TEntity> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dbSet.AsEnumerable().GetEnumerator();
        }
    }
}
