using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using HealthCare.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private HealthCareContext _context { get; }

        public Repository(HealthCareContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAllForGrid(
            List<Expression<Func<T, bool>>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int Page = 0, int Take = 10, params Expression<Func<T, object>>[] included)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var z in included)
            {
                query = query.Include(z);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
                query = query.Skip((Page - 1) * Take).Take(Take);
            }
            if (filter != null)
            {
                foreach (var z in filter)
                {
                    query = query.Where(z);
                }
            }
            return query.ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Get(Func<T, bool> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public virtual T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void DeleteById(object id)
        {
            T entityToDelete = _context.Set<T>().Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            T existing = _context.Set<T>().Find(entityToDelete);
            if (existing != null) _context.Set<T>().Remove(existing);
        }

        public virtual void Update(T entityToUpdate)
        {
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            _context.Set<T>().Attach(entityToUpdate);
        }
        public IQueryable<T> Query()
        {
            return _context.Query<T>();
        }
    }
}
