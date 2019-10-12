using System;
using System.Collections.Generic;
using System.IO;
using Capgemini.Inventory.Entities;
using Newtonsoft.Json;

namespace Capgemini.Inventory.Contracts.DALContracts
{
    /// <summary>
    /// This abstract class acts as a base for ProductDAL class
    /// </summary>
    public abstract class ProductDALBase
    {
        //Collection of Products
        protected static List<Product> productList = new List<Product>();
        private static string fileName = "Products.json";

        //Methods for CRUD operations
        public abstract bool AddProductDAL(Product newProduct);
        public abstract List<Product> GetAllProductsDAL();
        public abstract Product GetProductByProductIDDAL(Guid searchProductID);
        public abstract Product GetProductByProductNameDAL(string searchProductName);
        public abstract Product GetProductByProductCodeDAL(string searchProductCode);
        public abstract List<Product> GetProductsByProductTypeDAL(string searchProductType);
        public abstract bool UpdateProductDAL(Product updateProduct);
        public abstract bool DeleteProductDAL(Guid deleteProductID);

        /// <summary>
        /// Writes collection to the file in JSON format.
        /// </summary>
        public static void Serialize()
        {
            string serializedJson = JsonConvert.SerializeObject(productList);
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
                var systemUserListFromFile = JsonConvert.DeserializeObject<List<Product>>(fileContent);
                if (systemUserListFromFile != null)
                {
                    productList = systemUserListFromFile;
                }
            }
        }

        /// <summary>
        /// Static Constructor.
        /// </summary>
        static ProductDALBase()
        {
            Deserialize();
        }
    }
}