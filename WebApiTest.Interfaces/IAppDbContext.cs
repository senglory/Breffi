using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Interfaces
{
    public interface IAppDbContext : IDisposable
    {
        int GetToolTotalCount();
        QueryResultTool GetResultsTool(string filterByValue, int start, int length, Dictionary<string, string> orderBy);
        Tool FindToolById(Guid id);
        Guid AddTool(Tool dto);
        void UpdateTool(Tool dto);
        bool DeleteTool(Guid id);

        int GetToolTypeTotalCount();
        QueryResultToolType GetResultsToolType(string filterByValue, int start, int length, Dictionary<string, string> orderBy);
        ToolType FindToolTypeById(Guid id);
        Guid AddToolType(ToolType dto);
        void UpdateToolType(ToolType dto);
        bool DeleteToolType(Guid id);

        int GetBrandTotalCount();
        QueryResultBrand GetResultsBrand(string filterByValue, int start, int length, Dictionary<string, string> orderBy);
        Brand FindBrandById(Guid id);
        Guid AddBrand(Brand dto);
        void UpdateBrand(Brand dto);
        bool DeleteBrand(Guid id);



        IDictionary<Guid, Tool> GetToolsToBeAdded(IDictionary<Guid, Tool> src);
        //QueryResult<T> GetResults<T>(string filterByValue, int start, int length, Dictionary<string, string> orderBy) where T : BaseEntity;
    }
}
