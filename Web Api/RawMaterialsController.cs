using Inventory.Entities;
using System.Collections.Generic;
using System.Web.Http;
using Capgemini.Inventory.BusinessLayer;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System;

namespace Inventory.MVC.ApiControllers
{
    // Developed by Group 4
    // Creation Date : 2019/12/11
    // Last Modified Date : 

    public class RawMaterialsController : ApiController
    {
        private RawMaterialBL rawMaterialBL = new RawMaterialBL();

        //URL: api/rawMaterials
        public async Task<HttpResponseMessage> GetRawMaterials()
        {
            List<RawMaterial> rawMaterials = await rawMaterialBL.GetAllRawMaterialsBL();
            HttpResponseMessage response;
            response = Request.CreateResponse(HttpStatusCode.OK, rawMaterials);
            return response;
        }
        
        //URL: api/rawmaterials/id?
        [HttpDelete]
        public async Task<bool> DeleteRM(Guid id)
        {
            return await rawMaterialBL.DeleteRawMaterialBL(id);
        }
    }
}
