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
                ProductList.Add(newProduct);
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
            return ProductList;
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
                matchingProduct = ProductList.Find(
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
        /// <param name="ProductName">Represents ProductName to search.</param>
        /// <returns>Returns Product object.</returns>
        public override List<Product> GetProductsByNameDAL(string ProductName)
        {
            List<Product> matchingProducts = new List<Product>();
            try
            {
                //Find All Products based on ProductName
                matchingProducts = ProductList.FindAll(
                    (item) => { return item.ProductName.Equals(ProductName, StringComparison.OrdinalIgnoreCase); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingProducts;
        }

        /// <summary>
        /// Gets Product based on email.
        /// </summary>
        /// <param name="email">Represents Product's Email Address.</param>
        /// <returns>Returns Product object.</returns>
        public override Product GetProductByEmailDAL(string email)
        {
            Product matchingProduct = null;
            try
            {
                //Find Product based on Email and Password
                matchingProduct = ProductList.Find(
                    (item) => { return item.Email.Equals(email); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingProduct;
        }

        /// <summary>
        /// Gets Product based on Email and Password.
        /// </summary>
        /// <param name="email">Represents Product's Email Address.</param>
        /// <param name="password">Represents Product's Password.</param>
        /// <returns>Returns Product object.</returns>
        public override Product GetProductByEmailAndPasswordDAL(string email, string password)
        {
            Product matchingProduct = null;
            try
            {
                //Find Product based on Email and Password
                matchingProduct = ProductList.Find(
                    (item) => { return item.Email.Equals(email) && item.Password.Equals(password); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingProduct;
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
                    ReflectionHelpers.CopyProperties(updateProduct, matchingProduct, new List<string>() { "ProductName", "ProductMobile", "Email" });
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
                Product matchingProduct = ProductList.Find(
                    (item) => { return item.ProductID == deleteProductID; }
                );

                if (matchingProduct != null)
                {
                    //Delete Product from the collection
                    ProductList.Remove(matchingProduct);
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
        /// Updates Product's password based on ProductID.
        /// </summary>
        /// <param name="updateProduct">Represents Product details including ProductID, Password.</param>
        /// <returns>Determinates whether the existing Product's password is updated.</returns>
        public override bool UpdateProductPasswordDAL(Product updateProduct)
        {
            bool passwordUpdated = false;
            try
            {
                //Find Product based on ProductID
                Product matchingProduct = GetProductByProductIDDAL(updateProduct.ProductID);

                if (matchingProduct != null)
                {
                    //Update Product details
                    ReflectionHelpers.CopyProperties(updateProduct, matchingProduct, new List<string>() { "Password" });
                    matchingProduct.LastModifiedDateTime = DateTime.Now;

                    passwordUpdated = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return passwordUpdated;
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