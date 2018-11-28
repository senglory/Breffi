using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WebApiTest.Interfaces
{
    public class QueryResultBrand
    {
        public List<Brand> Data { get; private set; }
        public int FilteredCount { get; private set; }
        public int TotalCount { get; private set; }

        public QueryResultBrand(List<Brand> data, int filteredCount, int totalCount)
        {
            Data = data;
            FilteredCount = filteredCount;
            TotalCount = totalCount;
        }
    }
}