using System.Linq.Expressions;
using System.Reflection;
using StudentManagement.Data_Access.Interfaces;

namespace StudentManagement.Data_Access.Abstractions
{
    public abstract class AbstractFileRepository<T> : IRepository<T> where T: class, new()
    {
        protected readonly string _filePath;

        protected AbstractFileRepository(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (!File.Exists(_filePath))
                return new List<T>();

            return await ReadFromFileAsync();
        }
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var entities = await GetAllAsync();
            return entities.AsQueryable()
                           .Where(predicate)
                           .ToList();
        }
        public async Task<T> GetByIdAsync(object id)
        {
            var entities = await GetAllAsync();
            return entities.FirstOrDefault(entity => GetId(entity)?.Equals(id) == true);
        }
        public async Task CreateAsync(T entity)
        {
            var entities = (await GetAllAsync()).ToList();
            entities.Add(entity);
            await WriteToFileAsync(entities);
        }

        public async Task UpdateAsync(T entity)
        {
            var entities = (await GetAllAsync()).ToList();
            var id = GetId(entity);
            var index = entities.FindIndex(entity => GetId(entity)?.Equals(id) == true);

            if (index >= 0)
            {
                entities[index] = entity;
                await WriteToFileAsync(entities);
            }
        }

        public async Task DeleteAsync(T entity)
        {
            var entities = (await GetAllAsync()).ToList();
            var id = GetId(entity);
            var toRemove = entities.FirstOrDefault(entity => GetId(entity)?.Equals(id) == true);
            if (toRemove != null)
            {
                entities.Remove(toRemove);
                await WriteToFileAsync(entities);
            }
        }
        private object? GetId(T entity)
        {
            var property = typeof(T).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);
            return property?.GetValue(entity);
        }

        // Abstract I/O methods implemented by subclasses
        protected abstract Task<IEnumerable<T>> ReadFromFileAsync();
        protected abstract Task WriteToFileAsync(List<T> entities);
    }
}
