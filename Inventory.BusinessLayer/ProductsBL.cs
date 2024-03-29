using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Capgemini.Inventory.Contracts.BLContracts;
using Capgemini.Inventory.Contracts.DALContracts;
using Capgemini.Inventory.DataAccessLayer;
using Capgemini.Inventory.Entities;
using Capgemini.Inventory.Exceptions;
using Capgemini.Inventory.Helpers.ValidationAttributes;

namespace Capgemini.Inventory.BusinessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting Products from Product's collection.
    /// </summary>
    public class ProductBL : BLBase<Product>, IProductBL, IDisposable
    {
        //fields
        ProductDALBase productDAL;

        /// <summary>
        /// Constructor.
        /// </summary>
        public ProductBL()
        {
            this.productDAL = new ProductDAL();
        }

        /// <summary>
        /// Validations on data before adding or updating.
        /// </summary>
        /// <param name="entityObject">Represents object to be validated.</param>
        /// <returns>Returns a boolean value, that indicates whether the data is valid or not.</returns>
        protected async override Task<bool> Validate(Product entityObject)
        {
            //Create string builder
            StringBuilder sb = new StringBuilder();
            bool valid = await base.Validate(entityObject);

            //Name is Unique for each type
            var existingObject = await GetProductByProductNameBL(entityObject.ProductName);
            if (existingObject != null && existingObject?.ProductType == entityObject.ProductType)
            {
                valid = false;
                sb.Append(Environment.NewLine + $"Name {entityObject.ProductName} already exists");
            }

            //Code is Unique
            var existingObject2 = await GetProductByProductCodeBL(entityObject.ProductCode);
            if (existingObject2 != null)
            {
                valid = false;
                sb.Append(Environment.NewLine + $"Product Code {entityObject.ProductCode} already exists");
            }

            //Price is non negative
            if (entityObject.ProductPrice < 0)
            {
                valid = false;
                sb.Append(Environment.NewLine + $"Product Price {entityObject.ProductPrice} cannot be less than 0");
            }

            if (valid == false)
                throw new InventoryException(sb.ToString());
            return valid;
        }

        /// <summary>
        /// Adds new Product to Products collection.
        /// </summary>
        /// <param name="newProduct">Contains the Product details to be added.</param>
        /// <returns>Determinates whether the new Product is added.</returns>
        public async Task<bool> AddProductBL(Product newProduct)
        {
            bool ProductAdded = false;
            try
            {
                if (await Validate(newProduct))
                {
                    await Task.Run(() =>
                    {
                        this.productDAL.AddProductDAL(newProduct);
                        ProductAdded = true;
                        Serialize();
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ProductAdded;
        }

        /// <summary>
        /// Gets all Products from the collection.
        /// </summary>
        /// <returns>Returns list of all Products.</returns>
        public async Task<List<Product>> GetAllProductsBL()
        {
            List<Product> ProductsList = null;
            try
            {
                await Task.Run(() =>
                {
                    ProductsList = productDAL.GetAllProductsDAL();
                });
            }
            catch (Exception)
            {
                throw;
            }
            return ProductsList;
        }

        /// <summary>
        /// Gets Product based on ProductID.
        /// </summary>
        /// <param name="searchProductID">Represents ProductID to search.</param>
        /// <returns>Returns Product object.</returns>
        public async Task<Product> GetProductByProductIDBL(Guid searchProductID)
        {
            Product matchingProduct = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingProduct = productDAL.GetProductByProductIDDAL(searchProductID);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingProduct;
        }

        /// <summary>
        /// Gets Product based on ProductName
        /// </summary>
        /// <param name="searchProductName">Represents Product's Name.</param>
        /// <returns>Returns Product object.</returns>
        public async Task<Product> GetProductByProductNameBL(string searchProductName)
        {
            Product matchingProduct = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingProduct = productDAL.GetProductByProductNameDAL(searchProductName);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingProduct;
        }

        /// <summary>
        /// Gets Product based on ProductCode
        /// </summary>
        /// <param name="searchProductCode">Represents Product's Name.</param>
        /// <returns>Returns Product object.</returns>
        public async Task<Product> GetProductByProductCodeBL(string searchProductCode)
        {
            Product matchingProduct = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingProduct = productDAL.GetProductByProductCodeDAL(searchProductCode);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingProduct;
        }

        /// <summary>
        /// Gets Products based on ProductType.
        /// </summary>
        /// <param name="searchProductType">Represents ProductType to search.</param>
        /// <returns>Returns Product objects.</returns>
        public async Task<List<Product>> GetProductsByProductTypeBL(string searchProductType)
        {
            List<Product> matchingProducts = new List<Product>();
            try
            {
                await Task.Run(() =>
                {
                    matchingProducts = productDAL.GetProductsByProductTypeDAL(searchProductType);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingProducts;
        }

        /// <summary>
        /// Updates Product based on ProductID.
        /// </summary>
        /// <param name="updateProduct">Represents Product details including ProductID, ProductName etc.</param>
        /// <returns>Determinates whether the existing Product is updated.</returns>
        public async Task<bool> UpdateProductBL(Product updateProduct)
        {
            bool ProductUpdated = false;
            try
            {
                if ((await Validate(updateProduct)) && (await GetProductByProductIDBL(updateProduct.ProductID)) != null)
                {
                    this.productDAL.UpdateProductDAL(updateProduct);
                    ProductUpdated = true;
                    Serialize();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ProductUpdated;
        }

        /// <summary>
        /// Deletes Product based on ProductID.
        /// </summary>
        /// <param name="deleteProductID">Represents ProductID to delete.</param>
        /// <returns>Determinates whether the existing Product is updated.</returns>
        public async Task<bool> DeleteProductBL(Guid deleteProductID)
        {
            bool ProductDeleted = false;
            try
            {
                await Task.Run(() =>
                {
                    ProductDeleted = productDAL.DeleteProductDAL(deleteProductID);
                    Serialize();
                });
            }
            catch (Exception)
            {
                throw;
            }
            return ProductDeleted;
        }

        /// <summary>
        /// Disposes DAL object(s).
        /// </summary>
        public void Dispose()
        {
            ((ProductDAL)productDAL).Dispose();
        }

        /// <summary>
        /// Invokes Serialize method of DAL.
        /// </summary>
        public static void Serialize()
        {
            try
            {
                ProductDAL.Serialize();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///Invokes Deserialize method of DAL.
        /// </summary>
        public static void Deserialize()
        {
            try
            {
                ProductDAL.Deserialize();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
