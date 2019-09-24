using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capgemini.Inventory.Entities;
using Capgemini.Inventory.Exceptions;
using Capgemini.Inventory.Helpers;
using Capgemini.Inventory.Contracts.DALContracts;


namespace Capgemini.Inventory.DataAccessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting raw materials from RawMaterial collection.
    /// </summary>
    public class RawMaterialDAL : RawMaterialDALBase, IDisposable
    {
        /// <summary>
        /// Adds new RawMaterial to RawMaterials collection.
        /// </summary>
        /// <param name="newRawMaterial">Contains the RawMaterial details to be added.</param>
        /// <returns>Determinates whether the new RawMaterial is added.</returns>
        public override bool AddRawMaterialDAL(RawMaterial newRawMaterial)
        {
            bool RawMaterialAdded = false;
            try
            {
                newRawMaterial.RawMaterialID = Guid.NewGuid();
                newRawMaterial.CreationDateTime = DateTime.Now;
                newRawMaterial.LastModifiedDateTime = DateTime.Now;
                rawMaterialList.Add(newRawMaterial);
                RawMaterialAdded = true;
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
        public override List<RawMaterial> GetAllRawMaterialsDAL()
        {
            return rawMaterialList;
        }

        /// <summary>
        /// Gets RawMaterial based on RawMaterialID.
        /// </summary>
        /// <param name="searchRawMaterialID">Represents RawMaterialID to search.</param>
        /// <returns>Returns RawMaterial object.</returns>
        public override RawMaterial GetRawMaterialByRawMaterialIDDAL(Guid searchRawMaterialID)
        {
            RawMaterial matchingRawMaterial = null;
            try
            {
                //Find RawMaterial based on searchRawMaterialID
                matchingRawMaterial = rawMaterialList.Find(
                    (item) => { return item.RawMaterialID == searchRawMaterialID; }
                );
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
        public override RawMaterial GetRawMaterialByRawMaterialNameDAL(string searchRawMaterialName)
        {
            RawMaterial matchingRawMaterial = null;
            try
            {
                //Find All RawMaterials based on RawMaterialName
                matchingRawMaterial = rawMaterialList.Find(
                    (item) => { return item.RawMaterialName.Equals(searchRawMaterialName, StringComparison.OrdinalIgnoreCase); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingRawMaterial;
        }

        /// <summary>
        /// Gets RawMaterial based on Code.
        /// </summary>
        /// <param name="RawMaterialCode">Represents RawMaterial's Code.</param>
        /// <returns>Returns RawMaterial object.</returns>
        public override RawMaterial GetRawMaterialByRawMaterialCodeDAL(string searchRawMaterialCode)
        {
            RawMaterial matchingRawMaterial = null;
            try
            {
                //Find RawMaterial based on Code
                matchingRawMaterial = rawMaterialList.Find(
                    (item) => { return item.RawMaterialCode.Equals(searchRawMaterialCode); }
                );
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
        public override bool UpdateRawMaterialDAL(RawMaterial updateRawMaterial)
        {
            bool RawMaterialUpdated = false;
            try
            {
                //Find RawMaterial based on RawMaterialID
                RawMaterial matchingRawMaterial = GetRawMaterialByRawMaterialIDDAL(updateRawMaterial.RawMaterialID);

                if (matchingRawMaterial != null)
                {
                    //Update RawMaterial details
                    ReflectionHelpers.CopyProperties(updateRawMaterial, matchingRawMaterial, new List<string>() { "RawMaterialName", "RawMaterialCode", "RawMaterialPrice" });
                    matchingRawMaterial.LastModifiedDateTime = DateTime.Now;

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
        public override bool DeleteRawMaterialDAL(Guid deleteRawMaterialID)
        {
            bool RawMaterialDeleted = false;
            try
            {
                //Find RawMaterial based on searchRawMaterialID
                RawMaterial matchingRawMaterial = rawMaterialList.Find(
                    (item) => { return item.RawMaterialID == deleteRawMaterialID; }
                );

                if (matchingRawMaterial != null)
                {
                    //Delete RawMaterial from the collection
                    rawMaterialList.Remove(matchingRawMaterial);
                    RawMaterialDeleted = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RawMaterialDeleted;
        }

        /// <summary>
        /// Clears unmanaged resources such as db connections or file streams.
        /// </summary>
        public void Dispose()
        {
            //No unmanaged resources currently
        }
    }
}
