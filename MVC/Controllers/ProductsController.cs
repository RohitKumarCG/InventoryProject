using System;
using System.Collections.Generic;
using Capgemini.Inventory.BusinessLayer;
using Inventory.Entities;
using System.Web.Mvc;
using Inventory.Mvc.Models;
using System.Threading.Tasks;

namespace Inventory.Mvc.Controllers
{
    // Developed by Rohit Kumar (Group 4)
    // Creation Date : 2019/10/24
    // Last Modified Date : 2019/10/29

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

        // URL: Products/Create
        [HttpPost]
        public async Task<ActionResult> Create(ProductViewModel productVM)
        {
            bool isAdded;
            try
            {
                //creating object of ProductBL
                ProductBL productBL = new ProductBL();

                //creating object of Product and storing values of viewmodel
                Product product = new Product();
                product.ProductName = productVM.ProductName;
                product.ProductType = productVM.ProductType;
                product.ProductCode = productVM.ProductCode;
                product.ProductUnitPrice = Convert.ToDecimal(productVM.ProductUnitPrice);

                //calling Add method of BL
                isAdded = await productBL.AddProductBL(product);
                if (isAdded)
                {
                    return RedirectToAction("Display");
                }
                else
                {
                    return Content("Product not added");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // URL: Products/Display
        public async Task<ActionResult> Display()
        {
            try
            {
                //creating object of ProductBL
                ProductBL productBL = new ProductBL();

                //creating list of Product and ProductViewModel and storing all Product objects in productsListVM
                List<Product> productsList = await productBL.GetAllProductsBL();
                List<ProductViewModel> productsListVM = new List<ProductViewModel>();

                foreach (var item in productsList)
                {
                    ProductViewModel productVM = new ProductViewModel()
                    {
                        ProductID = item.ProductID,
                        ProductName = item.ProductName,
                        ProductType = item.ProductType,
                        ProductCode = item.ProductCode,
                        ProductUnitPrice = Convert.ToDouble(item.ProductUnitPrice)
                    };

                    productsListVM.Add(productVM);
                }
                return View(productsListVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // URL: Products/Edit/id
        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                //creating object of ProductBL
                ProductBL productBL = new ProductBL();
                Product product = await productBL.GetProductByProductIDBL(id);

                //Creating object of Product into ProductViewModel
                ProductViewModel productVM = new ProductViewModel();
                productVM.ProductID = product.ProductID;
                productVM.ProductName = product.ProductName;
                productVM.ProductType = product.ProductType;
                productVM.ProductCode = product.ProductCode;
                productVM.ProductUnitPrice = Convert.ToDouble(product.ProductUnitPrice);

                return View(productVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // URL: Products/Edit/id
        [HttpPost]
        public async Task<ActionResult> Edit(ProductViewModel productVM)
        {
            bool isUpdated = false;
            try
            {
                //Creating object of ProductBL
                ProductBL productBL = new ProductBL();

                //creating object of Product and storing values of viewmodel
                Product product = new Product();
                product.ProductID = productVM.ProductID;
                product.ProductName = productVM.ProductName;
                product.ProductType = productVM.ProductType;
                product.ProductCode = productVM.ProductCode;
                product.ProductUnitPrice = Convert.ToDecimal(productVM.ProductUnitPrice);

                //calling Update method of BL
                isUpdated = await productBL.UpdateProductBL(product);
                if (isUpdated)
                {
                    return RedirectToAction("Display");
                }
                else
                {
                    return Content("Product not updated");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // URL: Products/Delete/id
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                //creating object of ProductBL
                ProductBL productBL = new ProductBL();
                Product product = await productBL.GetProductByProductIDBL(id);

                //Creating object of Product into ProductViewModel
                ProductViewModel productVM = new ProductViewModel();
                productVM.ProductID = product.ProductID;
                productVM.ProductName = product.ProductName;
                productVM.ProductType = product.ProductType;
                productVM.ProductCode = product.ProductCode;
                productVM.ProductUnitPrice = Convert.ToDouble(product.ProductUnitPrice);

                return View(productVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // URL: Products/Delete/id
        [HttpPost]
        public async Task<ActionResult> Delete(ProductViewModel productVM)
        {
            bool isDeleted = false;
            try
            {
                //Creating object of ProductBL
                ProductBL productBL = new ProductBL();
                isDeleted = await productBL.DeleteProductBL(productVM.ProductID);
                if (isDeleted)
                {
                    return RedirectToAction("Display");
                }
                else
                {
                    return Content("Product not deleted");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}