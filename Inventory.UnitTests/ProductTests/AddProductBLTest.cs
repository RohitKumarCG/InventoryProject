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
    //Module Name: AddProductUnitTest
    //Project: Inventory

    [TestClass]
    public class AddProductBLTest
    {
        /// <summary>
        /// Add Product to the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task AddValidProduct()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = 30 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await productBL.AddProductBL(product);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
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
            Product product = new Product() { ProductName = null, ProductCode = "MAJ", ProductPrice = 30 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await productBL.AddProductBL(product);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
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
            Product product = new Product() { ProductName = "MangoJuice", ProductCode = null, ProductPrice = 30 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await productBL.AddProductBL(product);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Product Price can't be zero
        /// </summary>
        [TestMethod]
        public async Task ProductPriceCanNotBeZero()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = 0 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await productBL.AddProductBL(product);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Product Price can't be negative
        /// </summary>
        [TestMethod]
        public async Task ProductPriceCanNotBeNegative()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product() { ProductName = "MangoJuice", ProductCode = "MAJ", ProductPrice = -10 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await productBL.AddProductBL(product);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// ProductName should contain at least two characters
        /// </summary>
        [TestMethod]
        public async Task ProductNameShouldContainAtLeastTwoCharacters()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product() { ProductName = "M", ProductCode = "MAJ", ProductPrice = 30 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await productBL.AddProductBL(product);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// ProductCode should contain at least two characters
        /// </summary>
        [TestMethod]
        public async Task ProductCodeShouldContainAtLeastTwoCharacters()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product() { ProductName = "MangoJuice", ProductCode = "M", ProductPrice = 30 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await productBL.AddProductBL(product);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }
    }
}
