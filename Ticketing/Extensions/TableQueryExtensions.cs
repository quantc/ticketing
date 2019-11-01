using Microsoft.WindowsAzure.Storage.Table;

namespace Ticketing
{
    public static class TableQueryExtensions
    {
        internal static TableQuery<T> OrWhere<T>(this TableQuery<T> query, string propertyName, string equalityOperator, string propertyValue) where T: TableEntity, new()
        {
            var newFilter = TableQuery.GenerateFilterCondition(propertyName, equalityOperator, propertyValue);

            if (string.IsNullOrEmpty(query.FilterString))
            {
                query.FilterString = newFilter;
            }
            else
            {
                query.FilterString = TableQuery.CombineFilters(query.FilterString, TableOperators.Or, newFilter);
            }

            return query;
        }
    }
}
