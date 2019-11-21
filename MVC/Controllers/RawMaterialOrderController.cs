
using System.Collections.Generic;
using System.Web.Mvc;
using Capgemini.Inventory.BusinessLayer;
using Inventory.Mvc.Models;
using Inventory.Entities;
using System;
//using Inventory.MVC.ServiceReference1;
 

namespace Inventory.MVC.Controllers
{
    // Developed by Ritwik Sinha (Group 4)
    // Creation Date : 2019/10/24
    // Last Modified Date : 
    public class RawMaterialOrderController : Controller
    {
        private readonly object rawMaterialOrderViewModel;

        // GET: RawMaterialOrder
        // URL : RawMaterialOrder/Create
        public async System.Threading.Tasks.Task<ActionResult> Create()
        {
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            SupplierBL supplierBL = new SupplierBL();
            List<RawMaterial> rawMaterials = await rawMaterialBL.GetAllRawMaterialsBL();
            List<Supplier> suppliers = await supplierBL.GetAllSuppliersBL();

            ViewBag.list1 = new SelectList(rawMaterials, "RawMaterialID", "RawMaterialName");
            ViewBag.list2 = new SelectList(suppliers, "SupplierID", "SupplierName");
            //Creating and initializing viewmodel object
            RawMaterialOrderViewModel rawMaterialOrderViewModel = new RawMaterialOrderViewModel();
            //Calling view and passing viewmodel object to view
            return View(rawMaterialOrderViewModel);
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Create(RawMaterialOrderViewModel rawMaterialOrderModel)
        {
            //Create object of PersonsBL
            RawMaterialOrderBL rawMaterialOrderBL = new RawMaterialOrderBL();
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            SupplierBL supplierBL = new SupplierBL();

            //Creating object of Person EntityModel
            Rawmaterialorder1 rawMaterialOrder = new Rawmaterialorder1();
            RawMaterial rawMaterial = new RawMaterial();
            Supplier supplier = new Supplier();

            rawMaterial.RawMaterialName = rawMaterialOrderModel.RawMaterialName;
            // supplier.SupplierName = rawMaterialOrderModel.SupplierName;
            rawMaterialOrder.RawMaterialTotalPrice = Convert.ToDecimal(rawMaterialOrderModel.RawMaterialTotalQuantity);
            rawMaterialOrder.RawMaterialTotalQuantity = Convert.ToDecimal(rawMaterialOrderModel.RawMaterialTotalPrice);
            rawMaterialOrder.SupplierID = rawMaterialOrderModel.SupplierID;
            await rawMaterialOrderBL.AddRawMaterialOrderBL(rawMaterialOrder);
            /*Guid.Parse("D2FFE2AA-F298-46B3-A13B-650C00BD3919");*/

            //person.PersonName = personVM.PersonName;
            //person.Email = personVM.Email;
            //person.Age = personVM.Age;

            //Invoke the AddPerson method BL
            (bool isAdded, System.Guid id) = await rawMaterialOrderBL.AddRawMaterialOrderBL(rawMaterialOrder);
            if (isAdded)
            {
                //Go to Index action method of Persons Controller
                return RedirectToAction("Index");
            }
            else
            {
                //Return plain html / plain string
                return Content("Raw Material Order not added");
            }
        }

        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            //Creating object of PersonsBL
            RawMaterialOrderBL rawMaterialOrderBL = new RawMaterialOrderBL();
            SupplierBL supplierBL = new SupplierBL();


            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            List<RawMaterial> rawMaterials = await rawMaterialBL.GetAllRawMaterialsBL();
            ViewBag.list1 = new SelectList(rawMaterials, "RawMaterialName");

            //Getting list of persons from PersonsBL
            List<Rawmaterialorder1> rawMaterialOrders = await rawMaterialOrderBL.GetAllRawMaterialOrdersBL();

            //Create an empty collection of PersonViewModel
            List<RawMaterialOrderViewModel> rawMaterialOrderViewModel = new List<RawMaterialOrderViewModel>();
            //ServiceReference1.RawMaterialOrderServiceClient personsServiceClient = new ServiceReference1.RawMaterialOrderServiceClient();
            //ServiceReference1.RawMaterialOrderDataContract[] rawMaterialOrderDataContracts = personsServiceClient.GetAllRawMaterialOrder();
            ////Migrate (copy) data from EntityModel collection to ViewModel collection
            foreach (var item in rawMaterialOrders)
            {
                Supplier suppl = await supplierBL.GetSupplierBySupplierIDBL(item.SupplierID);
                RawMaterialOrderViewModel rawMaterialOrderVM = new RawMaterialOrderViewModel()
                {
                    //RawMaterialOrderID = item.RawMaterialOrderID,
                    //SupplierID = Convert.ToString(item.SupplierID),

                    RawMaterialOrderID = item.RawMaterialOrderID,

                    SupplierName = suppl.SupplierName,
                    RawMaterialTotalPrice = Convert.ToDouble(item.RawMaterialTotalPrice),
                    RawMaterialTotalQuantity = Convert.ToDouble(item.RawMaterialTotalQuantity)
                };
                rawMaterialOrderViewModel.Add(rawMaterialOrderVM);
                }

                //Call view & pass personVM collection to view
                return View(rawMaterialOrderViewModel);
        }


        // URL: Persons/Edit
        public async System.Threading.Tasks.Task<ActionResult> Edit(System.Guid id)
        {

            // person = personBL.GetPersonByPersonID(id);


            //Creating object of Person into PersonViewModel
            RawMaterialOrderViewModel rawMaterialOrderViewModel = new RawMaterialOrderViewModel();
            RawMaterialOrderBL rawMaterialOrderBL = new RawMaterialOrderBL();
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            SupplierBL supplierBL = new SupplierBL();

            //Creating object of Person EntityModel
            Rawmaterialorder1 rawMaterialOrder = new Rawmaterialorder1();
            RawMaterial rawMaterial = new RawMaterial();
            Supplier supplier = new Supplier();
            List<Rawmaterialorder1> rawMaterialOrders = await rawMaterialOrderBL.GetAllRawMaterialOrdersBL();

            rawMaterial.RawMaterialName = rawMaterialOrderViewModel.RawMaterialName;
            supplier.SupplierName = rawMaterialOrderViewModel.SupplierName;
            rawMaterialOrder.RawMaterialTotalPrice = Convert.ToDecimal(rawMaterialOrderViewModel.RawMaterialTotalPrice);
            rawMaterialOrder.RawMaterialTotalQuantity = Convert.ToDecimal(rawMaterialOrderViewModel.RawMaterialTotalQuantity);

            //Getting list of persons from PersonsBL
            ;

            //Add Persons to ViewBag
            ViewBag.PersonsList = new SelectList(rawMaterialOrders, "PersonID", "PersonName");

            return View(rawMaterialOrderViewModel);
        }
        public async System.Threading.Tasks.Task<ActionResult> Delete(Guid id)
        {
            {
                bool isDeleted = true;
                Guid id1 = new Guid();
                try
                {
                    //Creating object of RawMaterialBL
                    RawMaterialOrderBL rawMaterialorderBL = new RawMaterialOrderBL();
                    (isDeleted, id1) = await rawMaterialorderBL.DeleteRawMaterialOrderBL(id);
                    if (isDeleted)
                    {
                        return RedirectToAction("Index");
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
}