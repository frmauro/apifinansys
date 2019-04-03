using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace apifinansys.Contracts
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();
        Task<IEnumerable<T>> FindAllAsync();

        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);

        void Create(T entity);
        Task CreateAsync(T entity);

        void Update(T entity);
        Task UpdateAsync(T entity);

        void Delete(T entity);
        Task DeleteAsync(T entity);

        void Save();
        Task SaveAsync();
    }
}
