using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity: class, IEntity, new()
        where TContext: DbContext, new()
     {
        protected readonly TContext _context;

        public GenericRepository(TContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var entityToDelete = Get(e => e.Id == entity.Id);
            _context.Remove(entityToDelete);
            _context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context
                .Set<TEntity>()
                .FirstOrDefault(predicate);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
                return _context.Set<TEntity>().ToList();
            return _context.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            var entityToUpdate = Get(e => e.Id == entity.Id);
            entityToUpdate = entity;
            _context.Set<TEntity>().Update(entityToUpdate);
            _context.SaveChanges();
        }
    }
}
