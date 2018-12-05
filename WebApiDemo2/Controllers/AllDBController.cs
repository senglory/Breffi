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

namespace WebApiDemo2.Controllers
{
    public class AllDBController : ControllerBasic
    {
        [HttpPost]
        [Route("api/sync")]
        public IHttpActionResult Sync()
        {
            //var response = _dbContext.Sync(entities);
            var response = _dbContext.GetResultsTool("",0,10,null);

            return Json(response.Data);
        }
    }
}
