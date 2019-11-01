using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ticketing.Services
{
    public interface ITableRepostitory<T> where T : TableEntity
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(string propertyName, List<string> propertyValues);
        Task Create(T obj);
    }
}
