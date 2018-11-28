using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WebApiTest.Interfaces
{
    public class QueryResultTool
    {
        public List<Tool> Data { get; private set; }
        public int FilteredCount { get; private set; }
        public int TotalCount { get; private set; }

        public QueryResultTool(List<Tool> data, int filteredCount, int totalCount)
        {
            Data = data;
            FilteredCount = filteredCount;
            TotalCount = totalCount;
        }
    }
}