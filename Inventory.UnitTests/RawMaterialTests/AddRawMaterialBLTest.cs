using System;
using System.Threading.Tasks;
using Capgemini.Inventory.BusinessLayer;
using Capgemini.Inventory.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capgemini.Inventory.UnitTests
{
    //Developed by Rohit
    //Creation Date: 2019/10/01
    //Last Modified Date:
    //Module Name: RawMaterialUnitTesting
    //Project Name: Inventory.UnitTests

    [TestClass]
    public class AddRawMaterialBLTest
    {
        /// <summary>
        /// Add RawMaterial to the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task AddValidRawMaterial()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial = new RawMaterial() { RawMaterialName = "Banana", RawMaterialCode = "BAN", RawMaterialPrice = 25 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await rawMaterialBL.AddRawMaterialBL(rawMaterial);
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
        /// RawMaterial Name can't be null
        /// </summary>
        [TestMethod]
        public async Task RawMaterialNameCanNotBeNull()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial = new RawMaterial() { RawMaterialName = null, RawMaterialCode = "Man", RawMaterialPrice = 20};
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await rawMaterialBL.AddRawMaterialBL(rawMaterial);
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
        /// RawMaterial Code can't be null
        /// </summary>
        [TestMethod]
        public async Task RawMaterialCodeCanNotBeNull()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = null, RawMaterialPrice = 20};
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await rawMaterialBL.AddRawMaterialBL(rawMaterial);
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
        /// RawMaterial Price can't be less than 0
        /// </summary>
        [TestMethod]
        public async Task RawMaterialPriceCanNotBeLessThanZero()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "Man", RawMaterialPrice = -10 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await rawMaterialBL.AddRawMaterialBL(rawMaterial);
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
        /// RawMaterial Price can't be 0
        /// </summary>
        [TestMethod]
        public async Task RawMaterialPriceCanNotBeZero()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "Man", RawMaterialPrice = 0 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await rawMaterialBL.AddRawMaterialBL(rawMaterial);
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
        /// RawMaterialName should contain at least two characters
        /// </summary>
        [TestMethod]
        public async Task RawMaterialNameShouldContainAtLeastTwoCharacters()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial = new RawMaterial() { RawMaterialName = "M", RawMaterialCode = "Man", RawMaterialPrice = 20};
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await rawMaterialBL.AddRawMaterialBL(rawMaterial);
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
        /// RawMaterialCode should contain at least two characters
        /// </summary>
        [TestMethod]
        public async Task RawMaterialCodeShouldContainAtLeastTwoCharacters()
        {
            //Arrange
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            RawMaterial rawMaterial = new RawMaterial() { RawMaterialName = "Mango", RawMaterialCode = "M", RawMaterialPrice = 20 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await rawMaterialBL.AddRawMaterialBL(rawMaterial);
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