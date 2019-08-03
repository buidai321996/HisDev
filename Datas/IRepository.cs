using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Datas
{
    public interface IRepository<TEntity, TId>
        where TEntity : class, IEntity<TId>
        where TId : IEquatable<TId>
    {

        TEntity GetById(TId id);




        //List<TEntity> FindAll();



        void AddOrUpdate(TEntity entity);

        TEntity Add(TEntity entity);

        List<TEntity> AddRange(IEnumerable<TEntity> entities);

        TEntity Remove(TEntity entity);
        



        int SaveChanges();

        Task<int> SaveChangeAsync();
    }
    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : class, IEntity<int>
    {
    }
}