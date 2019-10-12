using System;
using System.Threading.Tasks;
using Capgemini.Inventory.BusinessLayer;
using Capgemini.Inventory.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capgemini.Inventory.UnitTests
{
    //Developed By Rohit
    //Creation Date: 01-10-2019
    //Last Modified Date:
    //Module Name: UpdateProductUnitTest
    //Project: Inventory

    [TestClass]
    public class UpdateProductBLTest
    {
        /// <summary>
        /// Update Product in the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task UpdateValidProduct()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product1 = new Product() { ProductName = "TonicWater", ProductCode = "TW", ProductPrice = 20 };
            await productBL.AddProductBL(product1);
            Product product2 = new Product() { ProductID = product1.ProductID, ProductName = "ToniccWater", ProductCode = "TWW", ProductPrice = 35 };
            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await productBL.UpdateProductBL(product2);
            }
            catch (Exception ex)
            {
                isUpdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isUpdated, errorMessage);
            }
        }

        /// <summary>
        /// Product Name can't be null
        /// </summary>
        [TestMethod]
        public async Task ProductNameCanNotBeNull()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product1 = new Product() { ProductName = "Gatorade", ProductCode = "GRT", ProductPrice = 30 };
            await productBL.AddProductBL(product1);
            Product product2 = new Product() { ProductID = product1.ProductID, ProductName = null, ProductCode = "GRD", ProductPrice = 35 };
            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await productBL.UpdateProductBL(product2);
            }
            catch (Exception ex)
            {
                isUpdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isUpdated, errorMessage);
            }
        }

        /// <summary>
        /// Product Code can't be null
        /// </summary>
        [TestMethod]
        public async Task ProductCodeCanNotBeNull()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product1 = new Product() { ProductName = "ColaCola", ProductCode = "CLCL", ProductPrice = 30 };
            await productBL.AddProductBL(product1);
            Product product2 = new Product() { ProductID = product1.ProductID, ProductName = "CocaCola", ProductCode = null, ProductPrice = 35 };
            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await productBL.UpdateProductBL(product2);
            }
            catch (Exception ex)
            {
                isUpdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isUpdated, errorMessage);
            }
        }

        /// <summary>
        /// Product Price can't be 0
        /// </summary>
        [TestMethod]
        public async Task ProductPriceCanNotBeZero()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product1 = new Product() { ProductName = "Sprite", ProductCode = "SP", ProductPrice = 30 };
            await productBL.AddProductBL(product1);
            Product product2 = new Product() { ProductID = product1.ProductID, ProductName = "Sprte", ProductCode = "SPT", ProductPrice = 0 };
            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await productBL.UpdateProductBL(product2);
            }
            catch (Exception ex)
            {
                isUpdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isUpdated, errorMessage);
            }
        }

        /// <summary>
        /// Product Price can't be less than 0
        /// </summary>
        [TestMethod]
        public async Task ProductPriceCanNotBeLessThanZero()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product1 = new Product() { ProductName = "Lemonlime", ProductCode = "LLM", ProductPrice = 30 };
            await productBL.AddProductBL(product1);
            Product product2 = new Product() { ProductID = product1.ProductID, ProductName = "LimeLemon", ProductCode = "LML", ProductPrice = -10 };
            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await productBL.UpdateProductBL(product2);
            }
            catch (Exception ex)
            {
                isUpdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isUpdated, errorMessage);
            }
        }

        /// <summary>
        /// Product Name should contain at least two characters
        /// </summary>
        [TestMethod]
        public async Task ProductNameShouldContainAtLeastTwoCharacters()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product1 = new Product() { ProductName = "Fanta", ProductCode = "FAT", ProductPrice = 30 };
            await productBL.AddProductBL(product1);
            Product product2 = new Product() { ProductID = product1.ProductID, ProductName = "M", ProductCode = "FAAT", ProductPrice = 40 };
            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await productBL.UpdateProductBL(product2);
            }
            catch (Exception ex)
            {
                isUpdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isUpdated, errorMessage);
            }
        }

        /// <summary>
        /// Product Code should contain at least two characters
        /// </summary>
        [TestMethod]
        public async Task ProductCodeShouldContainAtLeastTwoCharacters()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product1 = new Product() { ProductName = "Mirinda", ProductCode = "MRD", ProductPrice = 30 };
            await productBL.AddProductBL(product1);
            Product product2 = new Product() { ProductID = product1.ProductID, ProductName = "Mirindaa", ProductCode = "M", ProductPrice = 40 };
            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await productBL.UpdateProductBL(product2);
            }
            catch (Exception ex)
            {
                isUpdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isUpdated, errorMessage);
            }
        }

        /// <summary>
        /// Product ID should exist
        /// </summary>
        [TestMethod]
        public async Task ProductIDDoesNotExist()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product1 = new Product() { ProductName = "Dew", ProductCode = "DW", ProductPrice = 30 };
            await productBL.AddProductBL(product1);
            Product product2 = new Product() { ProductID = default(Guid), ProductName = "MDew", ProductCode = "MDW", ProductPrice = 40 };
            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await productBL.UpdateProductBL(product2);
            }
            catch (Exception ex)
            {
                isUpdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isUpdated, errorMessage);
            }
        }
    }
}