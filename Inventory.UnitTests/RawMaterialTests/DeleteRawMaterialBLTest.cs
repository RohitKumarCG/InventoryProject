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
    //Module Name: DeleteRawMaterialUnitTest
    //Project: Inventory
    [TestClass]
    public class DeleteRawMaterialBLTest
    {
        /// <summary>
        /// Delete RawMaterial in the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task DeleteValidRawMaterial()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            bool isDeleted = false;
            string errorMessage = null;

            //Act
            try
            {
                isDeleted = await rawMaterialBL.DeleteRawMaterialBL(rawMaterial1.RawMaterialID);
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
        /// RawMaterial ID should exist
        /// </summary>
        [TestMethod]
        public async Task RawMaterialIDDoesNotExist()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            bool isDeleted = false;
            string errorMessage = null;

            //Act
            try
            {
                isDeleted = await rawMaterialBL.DeleteRawMaterialBL(default(Guid));
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
