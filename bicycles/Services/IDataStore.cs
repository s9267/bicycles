using System.Collections.Generic;
using System.Threading.Tasks;

namespace bicycles
{
    public interface IDataStore<T>
    {
        Task<bool> AddAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(string id);
        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> FindAllAsync(bool forceRefresh = false);
    }
}
