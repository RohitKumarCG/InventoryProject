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
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Ppya", RawMaterialCode = "PUP", RawMaterialPrice = 20 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            RawMaterial rawMaterial2 = new RawMaterial() { RawMaterialID = rawMaterial1.RawMaterialID, RawMaterialName = "Paapaayaa", RawMaterialCode = "PPY", RawMaterialPrice = 25 };
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
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Gluucoseee", RawMaterialCode = "GGGL", RawMaterialPrice = 80 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            RawMaterial rawMaterial2 = new RawMaterial() { RawMaterialID = rawMaterial1.RawMaterialID, RawMaterialName = null, RawMaterialCode = "GGCC", RawMaterialPrice = 85 };
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
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Honey", RawMaterialCode = "HON", RawMaterialPrice = 40 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            RawMaterial rawMaterial2 = new RawMaterial() { RawMaterialID = rawMaterial1.RawMaterialID, RawMaterialName = "Honeyy", RawMaterialCode = null, RawMaterialPrice = 45 };
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
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Lactone", RawMaterialCode = "LAC", RawMaterialPrice = 100 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            RawMaterial rawMaterial2 = new RawMaterial() { RawMaterialID = rawMaterial1.RawMaterialID, RawMaterialName = "Preservative", RawMaterialCode = "PRES", RawMaterialPrice = 0 };
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
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Sugarcane", RawMaterialCode = "SUGC", RawMaterialPrice = 20 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            RawMaterial rawMaterial2 = new RawMaterial() { RawMaterialID = rawMaterial1.RawMaterialID, RawMaterialName = "SCane", RawMaterialCode = "SCA", RawMaterialPrice = -10 };
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
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Ester", RawMaterialCode = "EST", RawMaterialPrice = 20 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            RawMaterial rawMaterial2 = new RawMaterial() { RawMaterialID = rawMaterial1.RawMaterialID, RawMaterialName = "M", RawMaterialCode = "ESTE", RawMaterialPrice = 20 };
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
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Fructose", RawMaterialCode = "FRUC", RawMaterialPrice = 70 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            RawMaterial rawMaterial2 = new RawMaterial() { RawMaterialID = rawMaterial1.RawMaterialID, RawMaterialName = "Fructos", RawMaterialCode = "F", RawMaterialPrice = 80 };
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
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialName = "Citricaciddd", RawMaterialCode = "CITTA", RawMaterialPrice = 40 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            RawMaterial rawMaterial2 = new RawMaterial() { RawMaterialID = default(Guid), RawMaterialName = "CitriccA", RawMaterialCode = "CITZ", RawMaterialPrice = 45 };
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
                Assert.IsFalse(isUpdated, errorMessage);
            }
        }
    }
}
