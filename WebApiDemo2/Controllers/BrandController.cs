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
    public class BrandController : ControllerBasic
    {
        [Route("api/brand/{id?}")]
        public IHttpActionResult GetBrand(Guid id)
        {
            var res = _dbContext.FindBrandById(id);
            return Json(res);
        }

        [Route("api/brand")]
        public IHttpActionResult Get()
        {
            var res = new Brand();
            return Json(res);
        }

        [Route("api/brand")]
        public IHttpActionResult PostBrand([FromBody]Brand obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _dbContext.AddBrand(obj);
            return Json(res);
        }

        [Route("api/brand")]
        public IHttpActionResult PutBrand([FromBody]Brand obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbContext.UpdateBrand(obj);
            return Ok();
        }

        [Route("api/brand/{id?}")]
        public IHttpActionResult DeleteBrand(Guid id)
        {
            _dbContext.DeleteBrand(id);
            return Ok();
        }


        [Route("api/filter-brand")]
        public IHttpActionResult FindBrand([FromBody]DataTableRequest requestModel)
        {
            var orderBy = new Dictionary<string, string>();
            var sortedColumns = requestModel.Order;

            foreach (var column in sortedColumns)
            {
                orderBy[requestModel.Columns[column.Column].Data] = column.Dir;
            }

            var queryResult = _dbContext.GetResultsBrand(requestModel.Search.Value, requestModel.Start, requestModel.Length, orderBy);

            var response = new SearchResponseBrand
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
