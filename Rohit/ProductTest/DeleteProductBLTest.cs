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
    //Module Name: DeleteProductUnitTest
    //Project: Inventory
    [TestClass]
    public class DeleteProductBLTest
    {
        /// <summary>
        /// Delete Product in the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task DeleteValidProduct()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product1 = new Product() { ProductName = "PomegranateJuice", ProductCode = "PGJ", ProductPrice = 30 };
            await productBL.AddProductBL(product1);
            bool isDeleted = false;
            string errorMessage = null;

            //Act
            try
            {
                isDeleted = await productBL.DeleteProductBL(product1.ProductID);
            }
            catch (Exception ex)
            {
                isDeleted = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isDeleted, errorMessage);
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
            Product product1 = new Product() { ProductName = "LemonJuice", ProductCode = "LMJ", ProductPrice = 30 };
            await productBL.AddProductBL(product1);
            bool isDeleted = false;
            string errorMessage = null;

            //Act
            try
            {
                isDeleted = await productBL.DeleteProductBL(default(Guid));
            }
            catch (Exception ex)
            {
                isDeleted = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isDeleted, errorMessage);
            }
        }
    }
}