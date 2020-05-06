using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ticketing.Repositories.Interfaces
{
    public interface ITableRepository<T> where T : TableEntity
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(string propertyName, List<string> propertyValues);
        Task Create(T obj);
        Task CreateBatch(List<T> objects);
    }
}