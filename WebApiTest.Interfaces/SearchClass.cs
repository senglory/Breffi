using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Data.Entity;



namespace WebApiTest.Interfaces
{
    public class SearchClass<T> where T : class
    {
        public virtual QueryResult<T> GetResults(DbSet<T> query, string filterByValue, int start, int length, Dictionary<string, string> orderBy)
        {
            var totalCount = query.Count();

            #region Filtering
            // Apply filters for searching
            //if (filterByValue != string.Empty)
            //{
            //    var value = filterByValue.Trim();

            //    query = query.Where(p => p.Descr.Contains(value)
            //                       );
            //}

            var filteredCount = query.Count();

            #endregion Filtering

            #region Sorting
            // Sorting
            var orderByString = String.Empty;

            foreach (var column in orderBy)
            {
                orderByString += orderByString != String.Empty ? "," : "";
                orderByString += (column.Key) + (string.IsNullOrEmpty(column.Value) ? " asc" : " " + column.Value);
            }

            var query1 = query.OrderBy(orderByString == string.Empty ? "Desc asc" : orderByString);

            #endregion Sorting

            // Paging
            var query2 = query1.Skip(start).Take(length).ToList<T>();

            var queryResult = new QueryResult<T>(query2, query.Count(), totalCount);
            return queryResult;
        }
    }
}
