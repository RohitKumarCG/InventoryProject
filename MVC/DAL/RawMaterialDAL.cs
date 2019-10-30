using System;
using System.Collections.Generic;
using Inventory.Entities;
using Capgemini.Inventory.Contracts.DALContracts;
using System.Data;
using System.Linq;

namespace Capgemini.Inventory.DataAccessLayer
{
    // Developed by Rohit Kumar (Group 4)
    // Creation Date : 2019/09/22
    // Last Modified Date : 2019/10/25

    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting raw materials from RawMaterial database.
    /// </summary>
    public class RawMaterialDAL : RawMaterialDALBase, IDisposable
    {
        /// <summary>
        /// Adds new RawMaterial to RawMaterial database.
        /// </summary>
        /// <param name="newRawMaterial">Contains the RawMaterial details to be added.</param>
        /// <returns>Determinates whether the new RawMaterial is added.</returns>
        public override bool AddRawMaterialDAL(RawMaterial newRawMaterial)
        {
            bool isAdded = false;
            try
            {
                newRawMaterial.RawMaterialID = Guid.NewGuid();
                newRawMaterial.CreationDateTime = DateTime.Now;
                newRawMaterial.LastUpdateDateTime = DateTime.Now;

                //creating object of entities
                using (Entities db = new Entities())
                {
                    //calling stored procedure to add raw material
                    int rowsAffected = db.AddRawMaterial(newRawMaterial.RawMaterialID, newRawMaterial.RawMaterialName, newRawMaterial.RawMaterialCode, newRawMaterial.RawMaterialUnitPrice, newRawMaterial.CreationDateTime, newRawMaterial.LastUpdateDateTime);
                    if (rowsAffected == 1)
                    {
                        isAdded = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isAdded;
        }

        /// <summary>
        /// Gets all RawMaterials from the database and store in a list.
        /// </summary>
        /// <returns>Returns list of all RawMaterials.</returns>
        public override List<RawMaterial> GetAllRawMaterialsDAL()
        {
            List<RawMaterial> rawMaterialsList = new List<RawMaterial>();
            try
            {
                //creating object of entities
                using (Entities db = new Entities())
                {
                    //creating list of raw materials and storing table rows in it
                    rawMaterialsList = new List<RawMaterial>();
                    rawMaterialsList = db.RawMaterials.ToList();
                }
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
        public override RawMaterial GetRawMaterialByRawMaterialIDDAL(Guid searchRawMaterialID)
        {
            RawMaterial rawMaterial = new RawMaterial();
            try
            {
                //creating object of entities
                using (Entities db = new Entities())
                {
                    rawMaterial = db.RawMaterials.Where(temp => temp.RawMaterialID == searchRawMaterialID).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rawMaterial;
        }

        /// <summary>
        /// Gets RawMaterial based on RawMaterialName.
        /// </summary>
        /// <param name="RawMaterialName">Represents RawMaterialName to search.</param>
        /// <returns>Returns RawMaterial object.</returns>
        public override RawMaterial GetRawMaterialByRawMaterialNameDAL(string searchRawMaterialName)
        {
            RawMaterial rawMaterial = new RawMaterial();
            try
            {
                //creating object of entities
                using (Entities db = new Entities())
                {
                    rawMaterial = db.RawMaterials.Where(temp => temp.RawMaterialName == searchRawMaterialName).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rawMaterial;
        }

        /// <summary>
        /// Gets RawMaterial based on Code.
        /// </summary>
        /// <param name="RawMaterialCode">Represents RawMaterial's Code.</param>
        /// <returns>Returns RawMaterial object.</returns>
        public override RawMaterial GetRawMaterialByRawMaterialCodeDAL(string searchRawMaterialCode)
        {
            RawMaterial rawMaterial = new RawMaterial();
            try
            {
                //creating object of entities
                using (Entities db = new Entities())
                {
                    rawMaterial = db.RawMaterials.Where(temp => temp.RawMaterialCode == searchRawMaterialCode).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rawMaterial;
        }

        /// <summary>
        /// Updates RawMaterial based on RawMaterialID.
        /// </summary>
        /// <param name="updateRawMaterial">Represents RawMaterial details including RawMaterialID, RawMaterialName etc.</param>
        /// <returns>Determinates whether the existing RawMaterial is updated.</returns>
        public override bool UpdateRawMaterialDAL(RawMaterial updateRawMaterial)
        {
            bool isUpdated = false;
            updateRawMaterial.LastUpdateDateTime = DateTime.Now;
            try
            {
                //creating object of entities
                using (Entities db = new Entities())
                {
                    RawMaterial existingRawMaterial = db.RawMaterials.Where(temp => temp.RawMaterialID == updateRawMaterial.RawMaterialID).FirstOrDefault();

                    if (existingRawMaterial == null)
                    {
                        return isUpdated;
                    }
                    else
                    {
                        //making changes in existing raw material and saving changes
                        existingRawMaterial.RawMaterialName = updateRawMaterial.RawMaterialName;
                        existingRawMaterial.RawMaterialCode = updateRawMaterial.RawMaterialCode;
                        existingRawMaterial.RawMaterialUnitPrice = updateRawMaterial.RawMaterialUnitPrice;
                        db.SaveChanges();
                        isUpdated = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isUpdated;
        }

        /// <summary>
        /// Deletes RawMaterial based on RawMaterialID.
        /// </summary>
        /// <param name="deleteRawMaterialID">Represents RawMaterialID to delete.</param>
        /// <returns>Determinates whether the existing RawMaterial is deleted.</returns>
        public override bool DeleteRawMaterialDAL(Guid deleteRawMaterialID)
        {
            bool isDeleted = false;
            try
            {
                //creating object of entities
                using (Entities db = new Entities())
                {
                    RawMaterial existingRawMaterial = db.RawMaterials.Where(temp => temp.RawMaterialID == deleteRawMaterialID).FirstOrDefault();

                    if (existingRawMaterial == null)
                    {
                        return isDeleted;
                    }
                    else
                    {
                        //deleting raw material and saving changes
                        db.RawMaterials.Remove(existingRawMaterial);
                        db.SaveChanges();
                        isDeleted = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isDeleted;
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