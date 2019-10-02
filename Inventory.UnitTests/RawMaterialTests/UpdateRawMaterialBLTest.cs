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
    //Module Name: UpdateRawMaterialUnitTest
    //Project: Inventory

    [TestClass]
    public class UpdateRawMaterialBLTest
    {
        /// <summary>
        /// Update RawMaterial in the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task UpdateValidRawMaterial()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            RawMaterial rawMaterial2 = new RawMaterial() { RawMaterialID = rawMaterial1.RawMaterialID, RawMaterialName = "Mangoo", RawMaterialCode = "MAN", RawMaterialPrice = 25 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await rawMaterialBL.UpdateRawMaterialBL(rawMaterial2);
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
        /// Raw Material Name can't be null
        /// </summary>
        [TestMethod]
        public async Task RawMaterialNameCanNotBeNull()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            RawMaterial rawMaterial2 = new RawMaterial() { RawMaterialID = rawMaterial1.RawMaterialID, RawMaterialName = null, RawMaterialCode = "MAN", RawMaterialPrice = 25 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await rawMaterialBL.AddRawMaterialBL(rawMaterial2);
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
        /// Raw Material Code can't be null
        /// </summary>
        [TestMethod]
        public async Task RawMaterialCodeCanNotBeNull()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            RawMaterial rawMaterial2 = new RawMaterial() { RawMaterialID = rawMaterial1.RawMaterialID, RawMaterialName = "Mangoo", RawMaterialCode = null, RawMaterialPrice = 25 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await rawMaterialBL.AddRawMaterialBL(rawMaterial2);
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
        /// Raw Material Price can't be 0
        /// </summary>
        [TestMethod]
        public async Task RawMaterialPriceCanNotBeZero()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            RawMaterial rawMaterial2 = new RawMaterial() { RawMaterialID = rawMaterial1.RawMaterialID, RawMaterialName = "Mangoo", RawMaterialCode = "MAA", RawMaterialPrice = 0 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await rawMaterialBL.AddRawMaterialBL(rawMaterial2);
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
        /// Raw Material Price can't be less than 0
        /// </summary>
        [TestMethod]
        public async Task RawMaterialPriceCanNotBeLessThanZero()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            RawMaterial rawMaterial2 = new RawMaterial() { RawMaterialID = rawMaterial1.RawMaterialID, RawMaterialName = "Mangoo", RawMaterialCode = "MAA", RawMaterialPrice = -10 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await rawMaterialBL.AddRawMaterialBL(rawMaterial2);
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
        /// Raw Material Name should contain at least two characters
        /// </summary>
        [TestMethod]
        public async Task RawMaterialNameShouldContainAtLeastTwoCharacters()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            RawMaterial rawMaterial2 = new RawMaterial() { RawMaterialID = rawMaterial1.RawMaterialID, RawMaterialName = "M", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await rawMaterialBL.AddRawMaterialBL(rawMaterial2);
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
        /// Raw Material Code should contain at least two characters
        /// </summary>
        [TestMethod]
        public async Task RawMaterialCodeShouldContainAtLeastTwoCharacters()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            RawMaterial rawMaterial2 = new RawMaterial() { RawMaterialID = rawMaterial1.RawMaterialID, RawMaterialName = "Mangoo", RawMaterialCode = "M", RawMaterialPrice = 20 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await rawMaterialBL.AddRawMaterialBL(rawMaterial2);
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
        /// Raw Material ID should exist
        /// </summary>
        [TestMethod]
        public async Task RawMaterialIDDoesNotExist()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            RawMaterial rawMaterial2 = new RawMaterial() { RawMaterialID = default(Guid), RawMaterialName = "Mangoo", RawMaterialCode = "MAA", RawMaterialPrice = 20 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await rawMaterialBL.AddRawMaterialBL(rawMaterial2);
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
