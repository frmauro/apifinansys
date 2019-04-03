using apifinansys.Contracts;
using apifinansys.EFContext;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await this.FinansysContext.Set<T>().ToListAsync();
        }


        public IEnumerable<T> FindAll()
        {
            return this.FinansysContext.Set<T>();
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await this.FinansysContext.Set<T>().Where(expression).ToListAsync();
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

        public async Task SaveAsync()
        {
            await this.FinansysContext.SaveChangesAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await this.FinansysContext.Set<T>().AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            this.FinansysContext.Set<T>().Update(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            Delete(entity);
            await SaveAsync();
        }
    }
}
