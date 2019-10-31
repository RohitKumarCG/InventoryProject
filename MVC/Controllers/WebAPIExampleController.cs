using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Routing;
using Inventory.Entities;
using Capgemini.Inventory.BusinessLayer;

namespace Inventory.Mvc.Controllers
{
    public class WebAPIExampleController : ApiController
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        public async Task<IHttpActionResult> getAllRawMaterials()
        {
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            List<RawMaterial> rawMaterials = await rawMaterialBL.GetAllRawMaterialsBL();


            if(rawMaterials == null)
            {
                return NotFound();
            }
            return Ok(rawMaterials);
        }
    }
}
