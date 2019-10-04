using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Inventory.BusinessLayer;
using Capgemini.Inventory.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capgemini.Inventory.UnitTests
{
    //Developed By Rohit
    //Creation Date: 01-10-2019
    //Last Modified Date:
    //Module Name: GetProductUnitTest
    //Project: Inventory
    [TestClass]
    public class GetProductBLTest
    {
        /// <summary>
        /// Get all Products in the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task GetAllValidProducts()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = 30 };
            await productBL.AddProductBL(product);
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                List<Product> productList = await productBL.GetAllProductsBL();
                if (productList.Count > 0)
                {
                    isDisplayed = true;
                }
            }
            catch (Exception ex)
            {
                isDisplayed = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isDisplayed, errorMessage);
            }
        }

        /// <summary>
        /// Product List cannot be Empty
        /// </summary>
        [TestMethod]
        public async Task ProductListCanNotBeEmpty()
        {
            //Arrange
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                ProductBL productBL = new ProductBL();
                List<Product> productList = await productBL.GetAllProductsBL();
                if (productList.Count < 1)
                {
                    isDisplayed = true;
                }
            }
            catch (Exception ex)
            {
                isDisplayed = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isDisplayed, errorMessage);
            }
        }

        /// <summary>
        /// Get Product in the Collection if ID is valid.
        /// </summary>
        [TestMethod]
        public async Task GetValidProductByID()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = 30 };
            await productBL.AddProductBL(product);
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                Product product1 = await productBL.GetProductByProductIDBL(product.ProductID);
                if (product.ProductID == product1.ProductID)
                {
                    isDisplayed = true;
                }
            }
            catch (Exception ex)
            {
                isDisplayed = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isDisplayed, errorMessage);
            }
        }

        /// <summary>
        /// ProductID should exist.
        /// </summary>
        [TestMethod]
        public async Task ProductIDDoesNotExist()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = 30 };
            await productBL.AddProductBL(product);
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                Product product1 = await productBL.GetProductByProductIDBL(default(Guid));
            }
            catch (Exception ex)
            {
                isDisplayed = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isDisplayed, errorMessage);
            }
        }

        /// <summary>
        /// Get Product in the Collection if Name is valid.
        /// </summary>
        [TestMethod]
        public async Task GetValidProductByName()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = 30 };
            await productBL.AddProductBL(product);
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                Product product1 = await productBL.GetProductByProductNameBL(product.ProductName);
                if (product.ProductName == product1.ProductName)
                {
                    isDisplayed = true;
                }
            }
            catch (Exception ex)
            {
                isDisplayed = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isDisplayed, errorMessage);
            }
        }

        /// <summary>
        /// ProductName should exist.
        /// </summary>
        [TestMethod]
        public async Task ProductNameDoesNotExist()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = 30 };
            await productBL.AddProductBL(product);
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                Product product1 = await productBL.GetProductByProductNameBL("SomeName");
            }
            catch (Exception ex)
            {
                isDisplayed = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isDisplayed, errorMessage);
            }
        }

        /// <summary>
        /// Get Product in the Collection if Code is valid.
        /// </summary>
        [TestMethod]
        public async Task GetValidProductByCode()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = 30 };
            await productBL.AddProductBL(product);
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                Product product1 = await productBL.GetProductByProductCodeBL(product.ProductCode);
                if (product.ProductCode == product1.ProductCode)
                {
                    isDisplayed = true;
                }
            }
            catch (Exception ex)
            {
                isDisplayed = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isDisplayed, errorMessage);
            }
        }

        /// <summary>
        /// ProductCode should exist.
        /// </summary>
        [TestMethod]
        public async Task ProductCodeDoesNotExist()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = 30 };
            await productBL.AddProductBL(product);
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                Product product1 = await productBL.GetProductByProductCodeBL("SomeCode");
            }
            catch (Exception ex)
            {
                isDisplayed = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isDisplayed, errorMessage);
            }
        }
    }
}
