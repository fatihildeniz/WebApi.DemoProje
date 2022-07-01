using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Repository;


namespace WebApi.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {   
        private readonly AppDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>() ;
        }

        
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public List<TEntity> Get(Expression<Func<TEntity,bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking().ToList();
        }
       
        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void SetAsNoTrack(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Detached;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {

            return _dbSet.Where(expression);
        }

       
    }
}

