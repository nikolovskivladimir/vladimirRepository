using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HealthCare.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllForGrid(
            List<Expression<Func<T, bool>>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int Page = 0, int Take = 10, params Expression<Func<T, object>>[] included);

        IEnumerable<T> GetAll();
        T GetById(object id);
        T Get(Func<T, bool> predicate);
        void Insert(T entity);
        void DeleteById(object id);
        void Delete(T entityToDelete);
        void Update(T entityToUpdate);
        IQueryable<T> Query();
    }
}
