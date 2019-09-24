using System;
using System.Collections.Generic;
using System.IO;
using Capgemini.Inventory.Entities;
using Newtonsoft.Json;

namespace Capgemini.Inventory.Contracts.DALContracts
{
    /// <summary>
    /// This abstract class acts as a base for RawMaterialDAL class
    /// </summary>
    public abstract class RawMaterialDALBase
    {
        //Collection of RawMaterials
        protected static List<RawMaterial> RawMaterialList = new List<RawMaterial>();
        private static string fileName = "RawMaterials.json";

        //Methods for CRUD operations
        public abstract bool AddRawMaterialDAL(RawMaterial newRawMaterial);
        public abstract List<RawMaterial> GetAllRawMaterialsDAL();
        public abstract RawMaterial GetRawMaterialByRawMaterialIDDAL(Guid searchRawMaterialID);
        public abstract RawMaterial GetRawMaterialByRawMaterialNameDAL(string searchRawMaterialName);
        public abstract RawMaterial GetRawMaterialByRawMaterialCodeDAL(string searchRawMaterialCode);
        public abstract bool UpdateRawMaterialDAL(RawMaterial updateRawMaterial);
        public abstract bool DeleteRawMaterialDAL(Guid deleteRawMaterialID);

        /// <summary>
        /// Writes collection to the file in JSON format.
        /// </summary>
        public static void Serialize()
        {
            string serializedJson = JsonConvert.SerializeObject(RawMaterialList);
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                streamWriter.Write(serializedJson);
                streamWriter.Close();
            }
        }

        /// <summary>
        /// Reads collection from the file in JSON format.
        /// </summary>
        public static void Deserialize()
        {
            string fileContent = string.Empty;
            if (!File.Exists(fileName))
                File.Create(fileName).Close();

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                fileContent = streamReader.ReadToEnd();
                streamReader.Close();
                var systemUserListFromFile = JsonConvert.DeserializeObject<List<RawMaterial>>(fileContent);
                if (systemUserListFromFile != null)
                {
                    RawMaterialList = systemUserListFromFile;
                }
            }
        }

        /// <summary>
        /// Static Constructor.
        /// </summary>
        static RawMaterialDALBase()
        {
            Deserialize();
        }
    }
}