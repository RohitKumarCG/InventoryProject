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
            Product product1 = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = 20 };
            await productBL.AddProductBL(product1);
            Product product2 = new Product() { ProductID = product1.ProductID, ProductName = "MangooJuice", ProductCode = "MANJ", ProductPrice = 35 };
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
            Product product1 = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = 30 };
            await productBL.AddProductBL(product1);
            Product product2 = new Product() { ProductID = product1.ProductID, ProductName = null, ProductCode = "MANJ", ProductPrice = 35 };
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
            Product product1 = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = 30 };
            await productBL.AddProductBL(product1);
            Product product2 = new Product() { ProductID = product1.ProductID, ProductName = "MangooJuice", ProductCode = null, ProductPrice = 35 };
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
            Product product1 = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = 30 };
            await productBL.AddProductBL(product1);
            Product product2 = new Product() { ProductID = product1.ProductID, ProductName = "MangooJuice", ProductCode = "MAAJ", ProductPrice = 0 };
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
            Product product1 = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = 30 };
            await productBL.AddProductBL(product1);
            Product product2 = new Product() { ProductID = product1.ProductID, ProductName = "MangooJuice", ProductCode = "MAAJ", ProductPrice = -10 };
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
            Product product1 = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = 30 };
            await productBL.AddProductBL(product1);
            Product product2 = new Product() { ProductID = product1.ProductID, ProductName = "M", ProductCode = "MAAJ", ProductPrice = 40 };
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
            Product product1 = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = 30 };
            await productBL.AddProductBL(product1);
            Product product2 = new Product() { ProductID = product1.ProductID, ProductName = "MangooJuice", ProductCode = "M", ProductPrice = 40 };
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
            Product product1 = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = 30 };
            await productBL.AddProductBL(product1);
            Product product2 = new Product() { ProductID = default(Guid), ProductName = "MangooJuice", ProductCode = "MAAJ", ProductPrice = 40 };
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
