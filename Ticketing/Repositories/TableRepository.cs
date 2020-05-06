using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Ticketing.Attributes;
using Ticketing.Extensions;
using Ticketing.Repositories.Interfaces;
using Ticketing.Services;

namespace Ticketing.Repositories
{
    public class TableRepository<T> : ITableRepository<T> where T : TableEntity, new()
    {
        private readonly CloudTable table;

        public TableRepository()
        {
            var tableAttribute = typeof(T).GetCustomAttribute<TableNameAttribute>();

            var tableClient = StorageAccountProvider.Instance.CreateCloudTableClient();
            table = tableClient.GetTableReference(tableAttribute.TableName);
            table.CreateIfNotExistsAsync();
        }

        public async Task CreateBatch(List<T> objects)
        {
            TableBatchOperation batchOperation = new TableBatchOperation();

            foreach (var obj in objects)
            {
                batchOperation.Insert(obj);
            }            

            await table.ExecuteBatchAsync(batchOperation);
        }

        public async Task Create(T obj)
        {
            await AssertTableExists();

            var operation = TableOperation.Insert(obj);

            await table.ExecuteAsync(operation);    
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

        private async Task AssertTableExists()
        {
            var tableExists = await table.ExistsAsync();
            if (!tableExists)
            {
                await table.CreateIfNotExistsAsync();
            }
        }
    }
}
