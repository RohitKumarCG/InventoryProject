using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capgemini.Inventory.Contracts.DALContracts;
using Capgemini.Inventory.Entities;
using Capgemini.Inventory.Exceptions;
using Capgemini.Inventory.Helpers;

namespace Capgemini.Inventory.DataAccessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting Products from Products collection.
    /// </summary>
    public class ProductDAL : ProductDALBase, IDisposable
    {
        /// <summary>
        /// Adds new Product to Products collection.
        /// </summary>
        /// <param name="newProduct">Contains the Product details to be added.</param>
        /// <returns>Determinates whether the new Product is added.</returns>
        public override bool AddProductDAL(Product newProduct)
        {
            bool ProductAdded = false;
            try
            {
                newProduct.ProductID = Guid.NewGuid();
                newProduct.CreationDateTime = DateTime.Now;
                newProduct.LastModifiedDateTime = DateTime.Now;
                productList.Add(newProduct);
                ProductAdded = true;
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
        public override List<Product> GetAllProductsDAL()
        {
            return productList;
        }

        /// <summary>
        /// Gets Product based on ProductID.
        /// </summary>
        /// <param name="searchProductID">Represents ProductID to search.</param>
        /// <returns>Returns Product object.</returns>
        public override Product GetProductByProductIDDAL(Guid searchProductID)
        {
            Product matchingProduct = null;
            try
            {
                //Find Product based on searchProductID
                matchingProduct = productList.Find(
                    (item) => { return item.ProductID == searchProductID; }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingProduct;
        }

        /// <summary>
        /// Gets Product based on ProductName.
        /// </summary>
        /// <param name="searchProductName">Represents ProductName to search.</param>
        /// <returns>Returns Product object.</returns>
        public override Product GetProductByProductNameDAL(string searchProductName)
        {
            Product matchingProduct = null;
            try
            {
                //Find All Products based on ProductName
                matchingProduct = productList.Find(
                    (item) => { return item.ProductName.Equals(searchProductName, StringComparison.OrdinalIgnoreCase); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingProduct;
        }

        /// <summary>
        /// Gets Product based on ProductName.
        /// </summary>
        /// <param name="searchProductCode">Represents ProductName to search.</param>
        /// <returns>Returns Product object.</returns>
        public override Product GetProductByProductCodeDAL(string searchProductCode)
        {
            Product matchingProduct = null;
            try
            {
                //Find All Products based on ProductCode
                matchingProduct = productList.Find(
                    (item) => { return item.ProductCode.Equals(searchProductCode, StringComparison.OrdinalIgnoreCase); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingProduct;
        }

        /// <summary>
        /// Gets Products based on ProductName.
        /// </summary>
        /// <param name="searchProductType">Represents ProductType to search.</param>
        /// <returns>Returns list of Product objects.</returns>
        public override List<Product> GetProductsByProductTypeDAL(string searchProductType)
        {
            List<Product> matchingProducts = new List<Product>();
            try
            {
                //Find All Distributors based on distributorName
                matchingProducts = productList.FindAll(
                    (item) => { return item.ProductType.Equals(searchProductType, StringComparison.OrdinalIgnoreCase); }
                );
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
        public override bool UpdateProductDAL(Product updateProduct)
        {
            bool ProductUpdated = false;
            try
            {
                //Find Product based on ProductID
                Product matchingProduct = GetProductByProductIDDAL(updateProduct.ProductID);

                if (matchingProduct != null)
                {
                    //Update Product details
                    ReflectionHelpers.CopyProperties(updateProduct, matchingProduct, new List<string>() { "ProductName", "ProductCode", "ProductPrice" });
                    matchingProduct.LastModifiedDateTime = DateTime.Now;

                    ProductUpdated = true;
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
        public override bool DeleteProductDAL(Guid deleteProductID)
        {
            bool ProductDeleted = false;
            try
            {
                //Find Product based on searchProductID
                Product matchingProduct = productList.Find(
                    (item) => { return item.ProductID == deleteProductID; }
                );

                if (matchingProduct != null)
                {
                    //Delete Product from the collection
                    productList.Remove(matchingProduct);
                    ProductDeleted = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ProductDeleted;
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
