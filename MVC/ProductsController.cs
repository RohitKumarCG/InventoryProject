using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.Mvc.Models;

namespace Inventory.Mvc.Controllers
{
    // Developed by Rohit Kumar (Group 4)
    // Creation Date : 2019/10/24
    // Last Modified Date : 

    public class ProductsController : Controller
    {
        // URL: Products/Create
        public ActionResult Create()
        {
            //Creating and initializing viewmodel object
            ProductViewModel productViewModel = new ProductViewModel();
            
            //Calling view and passing viewmodel object to view
            return View(productViewModel);
        }
    }
}