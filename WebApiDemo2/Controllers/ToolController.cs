using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

using WebApiTest.Interfaces;
using Microsoft.Practices.Unity;
using WebApiDemo2.App_Start;



namespace WebApiDemo2.Controllers
{
    public class ToolController : ControllerBasic
    {
        [Route("api/tool/{id?}")]
        public IHttpActionResult GetTool(Guid id)
        {
            var res = _dbContext.FindToolById(id);
            return Json(res);
        }

        [Route("api/tool")]
        public IHttpActionResult Get()
        {
            var res = new Tool();
            return Json(res);
        }

        [Route("api/tool")]
        public IHttpActionResult PostTool([FromBody]Tool obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _dbContext.AddTool(obj);
            return Json(res);
        }

        [Route("api/tool")]
        public IHttpActionResult PutTool([FromBody]Tool obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbContext.UpdateTool(obj);
            return Ok();
        }

        [Route("api/tool/{id?}")]
        public IHttpActionResult DeleteTool(Guid id)
        {
            _dbContext.DeleteTool(id);
            return Ok();
        }


        [Route("api/filter-tool")]
        public IHttpActionResult FindTool([FromBody]DataTableRequest requestModel)
        {
            var orderBy = new Dictionary<string, string>();
            var sortedColumns = requestModel.Order;

            foreach (var column in sortedColumns)
            {
                orderBy[requestModel.Columns[column.Column].Data] = column.Dir;
            }

            var queryResult = _dbContext.GetResultsTool(requestModel.Search.Value, requestModel.Start, requestModel.Length, orderBy);

            var response = new SearchResponseTool
            {
                data = queryResult.Data,
                draw = requestModel.draw,
                recordsFiltered = queryResult.FilteredCount,
                recordsTotal = queryResult.TotalCount
            };
            return Json(response);
        }
    }
}
