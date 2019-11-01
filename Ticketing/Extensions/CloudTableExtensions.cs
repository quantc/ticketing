using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ticketing.Extensions
{
    public static class CloudTableExtensions
    {
        public static async Task<List<T>> ExecuteQueryAsync<T>(this CloudTable table, TableQuery<T> query, CancellationToken cancellationTtoken = default) where T : ITableEntity, new()
        {
            var items = new List<T>();
            TableContinuationToken continuationToken = null;

            do
            {
                TableQuerySegment<T> segment = await table.ExecuteQuerySegmentedAsync(query, continuationToken);
                continuationToken = segment.ContinuationToken;
                items.AddRange(segment);
            }
            while (continuationToken != null && !cancellationTtoken.IsCancellationRequested);

            return items;
        }
    }
}
