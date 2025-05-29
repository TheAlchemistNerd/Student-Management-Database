
using System.Linq.Expressions;


namespace StudentManagement.Data_Access.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T,bool>> predicate);
        Task<T> GetByIdAsync(object id);
        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
