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
using System.Net.Http;
using System.Web.Http.Description;

namespace WebApiDemo2.Controllers
{
    public class ToolController : ControllerBasic
    {
        [HttpGet]
        [Route("api/tool/{id?}")]
        public IHttpActionResult GetTool(Guid id)
        {
            var res = _dbContext.FindToolById(id);
            return Json(res);
        }

        [HttpGet]
        [Route("api/tool")]
        public IHttpActionResult Get()
        {
            var res = new Tool();
            return Json(res);
        }

        [HttpPost]
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

        [HttpPut]
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

        [HttpGet]
        [Route("api/tool/{id?}")]
        public IHttpActionResult DeleteTool(Guid id)
        {
            _dbContext.DeleteTool(id);
            return Ok();
        }

        [HttpPost]
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

        [HttpPost]
        //[ResponseType(typeof(FileUpload))]
        [Route("api/tool-import-csv")]
        public IHttpActionResult ImportCSV()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection  
                var httpPostedFile = HttpContext.Current.Request.Files["syncfile"];
                if (httpPostedFile != null)
                {
                    //FileUpload imgupload = new FileUpload();
                    int length = httpPostedFile.ContentLength;
                    var csvData = new byte[length];
                    httpPostedFile.InputStream.Read(csvData, 0, length);
                    var dataAsString = System.Text.Encoding.Default.GetString(csvData);
                    var lines = dataAsString.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    var lst = new Dictionary<Guid , Tool>();
                    foreach (var line in lines) {
                        var obj = Tool.FromCSV(line);
                        lst.Add (obj.ID , obj);
                    }

                    var lstToBeAdded = _dbContext.GetToolsToBeAdded(lst);

                    return Ok("Sync file processed");
                }
            }
            return NotFound();
        }
    }
}
