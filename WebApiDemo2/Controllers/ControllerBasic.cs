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
    public class ControllerBasic : ApiController
    {
        protected IAppDbContext _dbContext;

        public ControllerBasic()
        {
            var container = UnityConfig.GetConfiguredContainer();

            _dbContext = container.Resolve<IAppDbContext>();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}