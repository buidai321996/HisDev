using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Datas
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class, IEntity<TId> where TId : IEquatable<TId>
    {
        private readonly DbContext _dbContext;
        private IQueryable<TEntity> _queryable;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
            
        }

       

        protected IQueryable<TEntity> Queryable => _queryable ?? (_queryable = new Queryable<TEntity>(_dbContext));

        protected DbSet<TEntity> DbSet { get; set; }

        public TEntity Add(TEntity entity)
        {
            return DbSet.Add(entity);
        }

        public void AddOrUpdate(TEntity entity)
        {
            DbSet.AddOrUpdate(entity);
        }

        public List<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            return DbSet.AddRange(entities).ToList();
        }

       
        public List<TEntity> FindAll()
        {
            return DbSet.ToList();
        }

        public Task<List<TEntity>> FindAllAsync()
        {
            return DbSet.ToListAsync();
        }

        public TEntity GetById(TId id)
        {

            return DbSet.FirstOrDefault(it => it.Id.Equals(id));


        }



        public IEnumerator<TEntity> GetEnumerator()
        {
            return DbSet.AsEnumerable().GetEnumerator();
        }

        public TEntity Remove(TEntity entity)
        {
            var toRemode = GetById(entity.Id);
            if (toRemode == null)
                return null;
            else return DbSet.Remove(toRemode);

        }

        public Task<int> SaveChangeAsync()
        {
            return SaveChangeAsync();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

       
    }

    public class Repository<TEntity> : Repository<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        public Repository(DbContext dbContext) : base(dbContext)
        {
        }
    }


}
