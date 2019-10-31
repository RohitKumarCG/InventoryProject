using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.Mvc.Models;
using Capgemini.Inventory.BusinessLayer;
using Inventory.Entities;
using Capgemini.Inventory.Exceptions;
using System.Threading.Tasks;

namespace Inventory.Mvc.Controllers
{
    // Developed by Rohit Kumar (Group 4)
    // Creation Date : 2019/10/24
    // Last Modified Date : 2019/10/29

    public class RawMaterialsController : Controller
    {
        // URL: RawMaterials/Create
        public ActionResult Create()
        {
            //Creating and initializing viewmodel object
            RawMaterialViewModel rawMaterialViewModel = new RawMaterialViewModel();

            //Calling view and passing viewmodel object to view
            return View(rawMaterialViewModel);
        }

        // URL: RawMaterials/Create
        [HttpPost]
        public async Task<ActionResult> Create(RawMaterialViewModel rawMaterialVM)
        {
            bool isAdded;
            try
            {
                //creating object of RawMaterialBL
                RawMaterialBL rawMaterialBL = new RawMaterialBL();

                //creating object of RawMaterial and storing values of viewmodel
                RawMaterial rawMaterial = new RawMaterial();
                rawMaterial.RawMaterialName = rawMaterialVM.RawMaterialName;
                rawMaterial.RawMaterialCode = rawMaterialVM.RawMaterialCode;
                rawMaterial.RawMaterialUnitPrice = Convert.ToDecimal(rawMaterialVM.RawMaterialUnitPrice);

                //calling Add method of BL
                isAdded = await rawMaterialBL.AddRawMaterialBL(rawMaterial);
                if (isAdded)
                {
                    return RedirectToAction("Display");
                }
                else
                {
                    return Content("Raw Material not added");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // URL: RawMaterials/Display
        public async Task<ActionResult> Display()
        {
            try
            {
                //creating object of RawMaterialBL
                RawMaterialBL rawMaterialBL = new RawMaterialBL();

                //creating list of RawMaterial and RawMaterialViewModel and storing all RawMaterial objects in rawMaterialsListVM
                List<RawMaterial> rawMaterialsList = await rawMaterialBL.GetAllRawMaterialsBL();
                List<RawMaterialViewModel> rawMaterialsListVM = new List<RawMaterialViewModel>();

                //Create proxy: used to call the service
                ServiceReference1.RawMaterialsServiceClient rawMaterialsServiceClient = new ServiceReference1.RawMaterialsServiceClient();

                //Getting list of rawmaterials
                ServiceReference1.RawMaterialDataContract[] rawMaterialsDC = rawMaterialsServiceClient.GetRawMaterials();

                //foreach (var item in rawMaterialsList)
                //{
                //    RawMaterialViewModel rawMaterialVM = new RawMaterialViewModel()
                //    {
                //        RawMaterialID = item.RawMaterialID,
                //        RawMaterialName = item.RawMaterialName,
                //        RawMaterialCode = item.RawMaterialCode,
                //        RawMaterialUnitPrice = Convert.ToDouble(item.RawMaterialUnitPrice)
                //    };

                //    rawMaterialsListVM.Add(rawMaterialVM);
                //}

                //Convert data from DataContract to ViewModel
                List<RawMaterialViewModel> rawMaterialsVM = rawMaterialsDC
                    .Select
                    (temp => new RawMaterialViewModel()
                    {
                        RawMaterialID = temp.RawMaterialID,
                        RawMaterialName = temp.RawMaterialName,
                        RawMaterialCode = temp.RawMaterialCode,
                        RawMaterialUnitPrice = Convert.ToDecimal(temp.RawMaterialUnitPrice)
                    }
                ).ToList();

                //Calling view & passing viewmodel object to view
                return View(rawMaterialsVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // URL: RawMaterials/Edit/id
        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                //Creating object of RawMaterialBL
                RawMaterialBL rawMaterialBL = new RawMaterialBL();
                RawMaterial rawMaterial = await rawMaterialBL.GetRawMaterialByRawMaterialIDBL(id);
                
                //Creating object of RawMaterial into RawMaterialViewModel
                RawMaterialViewModel rawMaterialVM = new RawMaterialViewModel();
                rawMaterialVM.RawMaterialID = rawMaterial.RawMaterialID;
                rawMaterialVM.RawMaterialName = rawMaterial.RawMaterialName;
                rawMaterialVM.RawMaterialCode = rawMaterial.RawMaterialCode;
                rawMaterialVM.RawMaterialUnitPrice = Convert.ToDecimal(rawMaterial.RawMaterialUnitPrice);

                ////Getting list of persons from PersonsBL
                //List<Person> persons = personBL.GetPersons();

                ////Add Persons to ViewBag
                //ViewBag.PersonsList = new SelectList(persons, "PersonID", "PersonName");

                return View(rawMaterialVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // URL: RawMaterials/Edit/id
        [HttpPost]
        public async Task<ActionResult> Edit(RawMaterialViewModel rawMaterialVM)
        {
            bool isUpdated = false;
            try
            {
                //Creating object of RawMaterialBL
                RawMaterialBL rawMaterialBL = new RawMaterialBL();

                //creating object of RawMaterial and storing values of viewmodel
                RawMaterial rawMaterial = new RawMaterial();
                rawMaterial.RawMaterialID = rawMaterialVM.RawMaterialID;
                rawMaterial.RawMaterialName = rawMaterialVM.RawMaterialName;
                rawMaterial.RawMaterialCode = rawMaterialVM.RawMaterialCode;
                rawMaterial.RawMaterialUnitPrice = Convert.ToDecimal(rawMaterialVM.RawMaterialUnitPrice);

                //calling Update method of BL
                isUpdated = await rawMaterialBL.UpdateRawMaterialBL(rawMaterial);
                if (isUpdated)
                {
                    return RedirectToAction("Display");
                }
                else
                {
                    return Content("Raw Material not updated");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // URL: RawMaterials/Delete/id
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                //Creating object of RawMaterialBL
                RawMaterialBL rawMaterialBL = new RawMaterialBL();
                RawMaterial rawMaterial = await rawMaterialBL.GetRawMaterialByRawMaterialIDBL(id);

                //Creating object of RawMaterial into RawMaterialViewModel
                RawMaterialViewModel rawMaterialVM = new RawMaterialViewModel();
                rawMaterialVM.RawMaterialID = rawMaterial.RawMaterialID;
                rawMaterialVM.RawMaterialName = rawMaterial.RawMaterialName;
                rawMaterialVM.RawMaterialCode = rawMaterial.RawMaterialCode;
                rawMaterialVM.RawMaterialUnitPrice = Convert.ToDecimal(rawMaterial.RawMaterialUnitPrice);

                return View(rawMaterialVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // URL: RawMaterials/Delete/id
        [HttpPost]
        public async Task<ActionResult> Delete(RawMaterialViewModel rawMaterialViewModel)
        {
            bool isDeleted = false;
            try
            {
                //Creating object of RawMaterialBL
                RawMaterialBL rawMaterialBL = new RawMaterialBL();
                isDeleted = await rawMaterialBL.DeleteRawMaterialBL(rawMaterialViewModel.RawMaterialID);
                if (isDeleted)
                {
                    return RedirectToAction("Display");
                }
                else
                {
                    return Content("Raw Material not deleted");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}