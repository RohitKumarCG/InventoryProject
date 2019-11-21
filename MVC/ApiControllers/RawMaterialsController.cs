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
    // Developed by Rohit Kumar (Group 4)
    // Creation Date : 2019/11/12
    // Last Modified Date : 2019/11/21

    public class RawMaterialsController : ApiController
    {
        private RawMaterialBL rawMaterialBL = new RawMaterialBL();

        //URL: api/rawMaterials
        [HttpGet]
        public async Task<HttpResponseMessage> GetRawMaterials()
        {
            try
            {
                List<RawMaterial> rawMaterials = await rawMaterialBL.GetAllRawMaterialsBL();
                HttpResponseMessage response;
                response = Request.CreateResponse(HttpStatusCode.OK, rawMaterials);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //URL: api/rawMaterials
        [HttpPost]
        public async Task<IHttpActionResult> PostRawMaterials(RawMaterial rawMaterial)
        {
            try
            {
                bool isAdded = await rawMaterialBL.AddRawMaterialBL(rawMaterial);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //URL: api/rawMaterials
        [HttpPut]
        public async Task<IHttpActionResult> PutRawMaterials(RawMaterial rawMaterial)
        {
            try
            {
                await rawMaterialBL.UpdateRawMaterialBL(rawMaterial);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}