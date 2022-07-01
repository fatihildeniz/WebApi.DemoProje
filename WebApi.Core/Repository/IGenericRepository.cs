using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        List<TEntity> Get(Expression<Func<TEntity,bool>>expression);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void UpdateRange(IEnumerable<TEntity> entities);

        void SetAsNoTrack(TEntity entity);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

        

    }
}
