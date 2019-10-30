using System;
using System.Collections.Generic;
using Capgemini.Inventory.Contracts.DALContracts;
using Inventory.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace Capgemini.Inventory.DataAccessLayer
{
    // Developed by Rohit Kumar (Group 4)
    // Creation Date : 2019/09/22
    // Last Modified Date : 2019/10/25

    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting Products from Products collection.
    /// </summary>
    public class ProductDAL : ProductDALBase, IDisposable
    {
        /// <summary>
        /// Adds new Product to Product database.
        /// </summary>
        /// <param name="newProduct">Contains the Product details to be added.</param>
        /// <returns>Determinates whether the new Product is added.</returns>
        public override bool AddProductDAL(Product newProduct)
        {
            bool isAdded = false;
            try
            {
                newProduct.ProductID = Guid.NewGuid();
                newProduct.CreationDateTime = DateTime.Now;
                newProduct.LastUpdateDateTime = DateTime.Now;

                //creating object of entities
                using (Entities db = new Entities())
                {
                    //calling stored procedure to add product
                    int rowsAffected = db.AddProduct(newProduct.ProductID, newProduct.ProductType, newProduct.ProductName, newProduct.ProductCode, newProduct.ProductUnitPrice);
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
        /// Gets all Products from the database.
        /// </summary>
        /// <returns>Returns list of all Products.</returns>
        public override List<Product> GetAllProductsDAL()
        {
            List<Product> productsList = new List<Product>();
            try
            {
                //creating object of entities
                using (Entities db = new Entities())
                {
                    //creating list of products and storing table rows in it
                    productsList = new List<Product>();
                    productsList = db.Products.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return productsList;
        }

        /// <summary>
        /// Gets Product based on ProductID.
        /// </summary>
        /// <param name="searchProductID">Represents ProductID to search.</param>
        /// <returns>Returns Product object.</returns>
        public override Product GetProductByProductIDDAL(Guid searchProductID)
        {
            Product product = new Product();
            try
            {
                //creating object of entities
                using (Entities db = new Entities())
                {
                    product = db.Products.Where(temp => temp.ProductID == searchProductID).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }

        /// <summary>
        /// Gets Product based on ProductName.
        /// </summary>
        /// <param name="searchProductName">Represents ProductName to search.</param>
        /// <returns>Returns Product object.</returns>
        public override Product GetProductByProductNameDAL(string searchProductName)
        {
            Product product = new Product();
            try
            {
                //creating object of entities
                using (Entities db = new Entities())
                {
                    product = db.Products.Where(temp => temp.ProductName == searchProductName).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }

        /// <summary>
        /// Gets Product based on ProductCode.
        /// </summary>
        /// <param name="searchProductCode">Represents ProductName to search.</param>
        /// <returns>Returns Product object.</returns>
        public override Product GetProductByProductCodeDAL(string searchProductCode)
        {
            Product product = new Product();
            try
            {
                //creating object of entities
                using (Entities db = new Entities())
                {
                    product = db.Products.Where(temp => temp.ProductCode == searchProductCode).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }

        /// <summary>
        /// Gets Products based on ProductType.
        /// </summary>
        /// <param name="searchProductType">Represents ProductType to search.</param>
        /// <returns>Returns list of Product objects.</returns>
        public override List<Product> GetProductsByProductTypeDAL(string searchProductType)
        {
            List<Product> productsList = new List<Product>();
            try
            {
                //creating object of entities
                using (Entities db = new Entities())
                {
                     productsList = db.Products.Where(temp => temp.ProductType == searchProductType).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return productsList;
        }

        /// <summary>
        /// Updates Product based on ProductID.
        /// </summary>
        /// <param name="updateProduct">Represents Product details including ProductID, ProductName etc.</param>
        /// <returns>Determinates whether the existing Product is updated.</returns>
        public override bool UpdateProductDAL(Product updateProduct)
        {
            bool isUpdated = false;
            updateProduct.LastUpdateDateTime = DateTime.Now;
            try
            {
                //creating object of entities
                using (Entities db = new Entities())
                {
                    Product existingProduct = db.Products.Where(temp => temp.ProductID == updateProduct.ProductID).FirstOrDefault();

                    if (existingProduct == null)
                    {
                        return isUpdated;
                    }
                    else
                    {
                        //making changes in existing product and saving changes
                        existingProduct.ProductName = updateProduct.ProductName;
                        existingProduct.ProductCode = updateProduct.ProductCode;
                        existingProduct.ProductUnitPrice = updateProduct.ProductUnitPrice;
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
        /// Deletes Product based on ProductID.
        /// </summary>
        /// <param name="deleteProductID">Represents ProductID to delete.</param>
        /// <returns>Determinates whether the existing Product is deleted.</returns>
        public override bool DeleteProductDAL(Guid deleteProductID)
        {
            bool isDeleted = false;
            try
            {
                //creating object of entities
                using (Entities db = new Entities())
                {
                    Product existingProduct = db.Products.Where(temp => temp.ProductID == deleteProductID).FirstOrDefault();

                    if (existingProduct == null)
                    {
                        return isDeleted;
                    }
                    else
                    {
                        //deleting raw material and saving changes
                        db.Products.Remove(existingProduct);
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

