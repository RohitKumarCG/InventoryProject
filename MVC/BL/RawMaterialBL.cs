using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Inventory.Contracts.BLContracts;
using Capgemini.Inventory.Contracts.DALContracts;
using Capgemini.Inventory.DataAccessLayer;
using Inventory.Entities;
using Capgemini.Inventory.Exceptions;

namespace Capgemini.Inventory.BusinessLayer
{
    // Developed by Rohit Kumar (Group 4)
    // Creation Date : 2019/09/22
    // Last Modified Date : 2019/10/01

    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting RawMaterials from RawMaterial's collection.
    /// </summary>
    public class RawMaterialBL : BLBase<RawMaterial>, IRawMaterialBL, IDisposable
    {
        //fields
        RawMaterialDALBase rawMaterialDAL;

        /// <summary>
        /// Constructor.
        /// </summary>
        public RawMaterialBL()
        {
            this.rawMaterialDAL = new RawMaterialDAL();
        }

        /// <summary>
        /// Validations on data before adding or updating.
        /// </summary>
        /// <param name="entityObject">Represents object to be validated.</param>
        /// <returns>Returns a boolean value, that indicates whether the data is valid or not.</returns>
        protected async override Task<bool> Validate(RawMaterial entityObject)
        {
            //Create string builder
            StringBuilder sb = new StringBuilder();
            bool valid = await base.Validate(entityObject);

            ////Name is Unique
            //var existingObject1 = await GetRawMaterialByRawMaterialNameBL(entityObject.RawMaterialName);
            //if (existingObject1 != null && existingObject1?.RawMaterialID != entityObject.RawMaterialID)
            //{
            //    valid = false;
            //    sb.Append(Environment.NewLine + $"Raw Material Name {entityObject.RawMaterialName} already exists");
            //}

            ////Code is Unique
            //var existingObject2 = await GetRawMaterialByRawMaterialCodeBL(entityObject.RawMaterialCode);
            //if (existingObject2 != null && existingObject2?.RawMaterialID != entityObject.RawMaterialID)
            //{
            //    valid = false;
            //    sb.Append(Environment.NewLine + $"Raw Material Code {entityObject.RawMaterialCode} already exists");
            //}

            //Price is non negative
            if (entityObject.RawMaterialUnitPrice <= 0)
            {
                valid = false;
                sb.Append(Environment.NewLine + $"Raw Material Price {entityObject.RawMaterialUnitPrice} cannot be less than 0");
            }

            if (valid == false)
            {
                Console.WriteLine("Comes Here");
                throw new InventoryException(sb.ToString());
            }
                
            return valid;
        }

        /// <summary>
        /// Adds new RawMaterial to RawMaterials collection.
        /// </summary>
        /// <param name="newRawMaterial">Contains the RawMaterial details to be added.</param>
        /// <returns>Determinates whether the new RawMaterial is added.</returns>
        public async Task<bool> AddRawMaterialBL(RawMaterial newRawMaterial)
        {
            bool RawMaterialAdded = false;
            try
            {
                if (await Validate(newRawMaterial))
                {
                    await Task.Run(() =>
                    {
                        this.rawMaterialDAL.AddRawMaterialDAL(newRawMaterial);
                        RawMaterialAdded = true;
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RawMaterialAdded;
        }

        /// <summary>
        /// Gets all RawMaterials from the collection.
        /// </summary>
        /// <returns>Returns list of all RawMaterials.</returns>
        public async Task<List<RawMaterial>> GetAllRawMaterialsBL()
        {
            List<RawMaterial> rawMaterialsList = null;
            try
            {
                await Task.Run(() =>
                {
                    rawMaterialsList = rawMaterialDAL.GetAllRawMaterialsDAL();
                });
            }
            catch (Exception)
            {
                throw;
            }
            return rawMaterialsList;
        }

        /// <summary>
        /// Gets RawMaterial based on RawMaterialID.
        /// </summary>
        /// <param name="searchRawMaterialID">Represents RawMaterialID to search.</param>
        /// <returns>Returns RawMaterial object.</returns>
        public async Task<RawMaterial> GetRawMaterialByRawMaterialIDBL(Guid searchRawMaterialID)
        {
            RawMaterial matchingRawMaterial = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingRawMaterial = rawMaterialDAL.GetRawMaterialByRawMaterialIDDAL(searchRawMaterialID);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingRawMaterial;
        }

        /// <summary>
        /// Gets RawMaterial based on RawMaterialName.
        /// </summary>
        /// <param name="RawMaterialName">Represents RawMaterialName to search.</param>
        /// <returns>Returns RawMaterial object.</returns>
        public async Task<RawMaterial> GetRawMaterialByRawMaterialNameBL(string searchRawMaterialName)
        {
            RawMaterial matchingRawMaterial = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingRawMaterial = rawMaterialDAL.GetRawMaterialByRawMaterialNameDAL(searchRawMaterialName);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingRawMaterial;
        }

        /// <summary>
        /// Gets RawMaterial based on RawMaterialCode.
        /// </summary>
        /// <param name="searchRawMaterialCode">Represents RawMaterialCode to search.</param>
        /// <returns>Returns RawMaterial object.</returns>
        public async Task<RawMaterial> GetRawMaterialByRawMaterialCodeBL(string searchRawMaterialCode)
        {
            RawMaterial matchingRawMaterial = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingRawMaterial = rawMaterialDAL.GetRawMaterialByRawMaterialCodeDAL(searchRawMaterialCode);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingRawMaterial;
        }

        /// <summary>
        /// Updates RawMaterial based on RawMaterialID.
        /// </summary>
        /// <param name="updateRawMaterial">Represents RawMaterial details including RawMaterialID, RawMaterialName etc.</param>
        /// <returns>Determinates whether the existing RawMaterial is updated.</returns>
        public async Task<bool> UpdateRawMaterialBL(RawMaterial updateRawMaterial)
        {
            bool RawMaterialUpdated = false;
            try
            {
                bool check = await Validate(updateRawMaterial);
                if(check == false)
                {
                    return RawMaterialUpdated;
                }
                if (check && (await GetRawMaterialByRawMaterialIDBL(updateRawMaterial.RawMaterialID)) != null)
                {
                    this.rawMaterialDAL.UpdateRawMaterialDAL(updateRawMaterial);
                    RawMaterialUpdated = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RawMaterialUpdated;
        }

        /// <summary>
        /// Deletes RawMaterial based on RawMaterialID.
        /// </summary>
        /// <param name="deleteRawMaterialID">Represents RawMaterialID to delete.</param>
        /// <returns>Determinates whether the existing RawMaterial is updated.</returns>
        public async Task<bool> DeleteRawMaterialBL(Guid deleteRawMaterialID)
        {
            bool RawMaterialDeleted = false;
            try
            {
                await Task.Run(() =>
                {
                    RawMaterialDeleted = rawMaterialDAL.DeleteRawMaterialDAL(deleteRawMaterialID);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return RawMaterialDeleted;
        }

        /// <summary>
        /// Disposes DAL object(s).
        /// </summary>
        public void Dispose()
        {
            ((RawMaterialDAL)rawMaterialDAL).Dispose();
        }
    }
}