using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IGenericRepository<TEntity>
        where TEntity: class, IEntity, new()
    {
        List<TEntity> GetAll(Expression<Func<TEntity,bool>> filter = null);
        TEntity Get(Expression<Func<TEntity,bool>> predicate);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
