using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Ticketing.Attributes;
using Ticketing.Extensions;
using Ticketing.Services;

namespace Ticketing.Respositories
{
    public class TableRepository<T> : ITableRepostitory<T> where T : TableEntity, new()
    {
        private readonly CloudTable table;

        public TableRepository()
        {
            var tableAttribute = typeof(T).GetCustomAttribute<TableNameAttribute>();

            var tableClient = StorageAccountProvider.Instance.CreateCloudTableClient();
            table = tableClient.GetTableReference(tableAttribute.TableName);
            table.CreateIfNotExistsAsync();
        }

        public async Task Create(T obj)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAll()
        {
            var query = new TableQuery<T>(); 
            return await table.ExecuteQueryAsync(query);
        }

        public async Task<List<T>> GetAll(string propertyName, List<string> propertyValues)
        {
            var query = new TableQuery<T>();

            foreach (var propertyValue in propertyValues)
            {
                query.OrWhere<T>(propertyName, QueryComparisons.Equal, propertyValue);
            }

            return await table.ExecuteQueryAsync(query);
        }
    }
}
