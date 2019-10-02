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
    //Module Name: GetRawMaterialUnitTest
    //Project: Inventory
    [TestClass]
    public class GetRawMaterialBLTest
    {
        /// <summary>
        /// Get all RawMaterials in the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task GetAllValidRawMaterials()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial);
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                List<RawMaterial> rawMaterialList = await rawMaterialBL.GetAllRawMaterialsBL();
                if (rawMaterialList.Count < 1)
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
        /// Raw Material List cannot be Empty
        /// </summary>
        [TestMethod]
        public async Task RawMaterialListCanNotBeEmpty()
        {
            //Arrange
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                RawMaterialBL rawMaterialBL = new RawMaterialBL();
                List<RawMaterial> rawMaterialList = await rawMaterialBL.GetAllRawMaterialsBL();
                if (rawMaterialList.Count < 1)
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
        /// Get RawMaterial in the Collection if ID is valid.
        /// </summary>
        [TestMethod]
        public async Task GetValidRawMaterialByID()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial);
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                RawMaterial rawMaterial1 = await rawMaterialBL.GetRawMaterialByRawMaterialIDBL(rawMaterial.RawMaterialID);
                if (rawMaterial.RawMaterialID == rawMaterial1.RawMaterialID)
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
        /// RawMaterialID should exist.
        /// </summary>
        [TestMethod]
        public async Task RawMaterialIDDoesNotExist()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial);
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                RawMaterial rawMaterial1 = await rawMaterialBL.GetRawMaterialByRawMaterialIDBL(default(Guid));
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
        /// Get RawMaterial in the Collection if Name is valid.
        /// </summary>
        [TestMethod]
        public async Task GetValidRawMaterialByName()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial);
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                RawMaterial rawMaterial1 = await rawMaterialBL.GetRawMaterialByRawMaterialNameBL(rawMaterial.RawMaterialName);
                if (rawMaterial.RawMaterialName == rawMaterial1.RawMaterialName)
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
        /// RawMaterialName should exist.
        /// </summary>
        [TestMethod]
        public async Task RawMaterialNameDoesNotExist()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial);
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                RawMaterial rawMaterial1 = await rawMaterialBL.GetRawMaterialByRawMaterialNameBL("SomeName");
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
        /// Get RawMaterial in the Collection if Code is valid.
        /// </summary>
        [TestMethod]
        public async Task GetValidRawMaterialByCode()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial);
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                RawMaterial rawMaterial1 = await rawMaterialBL.GetRawMaterialByRawMaterialCodeBL(rawMaterial.RawMaterialCode);
                if (rawMaterial.RawMaterialCode == rawMaterial1.RawMaterialCode)
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
        /// RawMaterialCode should exist.
        /// </summary>
        [TestMethod]
        public async Task RawMaterialCodeDoesNotExist()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "MA", RawMaterialPrice = 20 };
            await rawMaterialBL.AddRawMaterialBL(rawMaterial);
            bool isDisplayed = false;
            string errorMessage = null;

            //Act
            try
            {
                RawMaterial rawMaterial1 = await rawMaterialBL.GetRawMaterialByRawMaterialCodeBL("SomeCode");
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