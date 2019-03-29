using apifinansys.Contracts;
using apifinansys.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace apifinansys.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected FinansysContext FinansysContext { get; set; }

        public RepositoryBase(FinansysContext finansysContext)
        {
            this.FinansysContext = finansysContext;
        }

        public IEnumerable<T> FindAll()
        {
            return this.FinansysContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.FinansysContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            this.FinansysContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.FinansysContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.FinansysContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.FinansysContext.SaveChanges();
        }
    }
}
