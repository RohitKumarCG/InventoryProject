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
            Product product = new Product() { ProductName = "CokeDiet", ProductCode = "CDK", ProductPrice = 30 };
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
        /// Get all Products in the Collection of the specified type if it is valid.
        /// </summary>
        [TestMethod]
        public async Task GetAllValidProductsByType()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product() { ProductType = "Juice", ProductName = "SweetSoda", ProductCode = "SSD", ProductPrice = 30 };
            await productBL.AddProductBL(product);
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                List<Product> productList = await productBL.GetProductsByProductTypeBL("Juice");
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
        /// ProductType does not exist.
        /// </summary>
        [TestMethod]
        public async Task ProductTypeDoesNotExist()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product() { ProductType = "Juice", ProductName = "PlainSoda", ProductCode = "PSD", ProductPrice = 30 };
            await productBL.AddProductBL(product);
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                List<Product> productList = await productBL.GetProductsByProductTypeBL("SomeType");
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
                Assert.IsFalse(isDisplayed, errorMessage);
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
            Product product = new Product() { ProductName = "CokeZero", ProductCode = "CZO", ProductPrice = 30 };
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
            Product product = new Product() { ProductName = "ThumsUp", ProductCode = "TUP", ProductPrice = 30 };
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
            Product product = new Product() { ProductName = "Slice", ProductCode = "SLC", ProductPrice = 30 };
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
            Product product = new Product() { ProductName = "GrapeJuice", ProductCode = "GPJ", ProductPrice = 30 };
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
            Product product = new Product() { ProductName = "IceTea", ProductCode = "IT", ProductPrice = 30 };
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
            Product product = new Product() { ProductName = "ColdCoffee", ProductCode = "CFF", ProductPrice = 30 };
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