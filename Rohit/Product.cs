using System;
using Capgemini.Inventory.Helpers.ValidationAttributes;

namespace Capgemini.Inventory.Entities
{
    /// Developed by Rohit
    /// <summary>
    /// Interface for Product Entity
    /// </summary>
    public interface IProduct
    {
        Guid ProductID { get; set; }
        string ProductName { get; set; }
        string ProductCode { get; set; } 
        string ProductType { get; set; }
        double ProductPrice { get; set; }
        DateTime CreationDateTime { get; set; }
        DateTime LastModifiedDateTime { get; set; }
    }

    /// <summary>
    /// Represents Product
    /// </summary>
    public class Product : IProduct
    {
        /* Auto-Implemented Properties */
        [Required("Product ID can't be blank.")]
        public Guid ProductID { get; set; }

        [Required("Product Name can't be blank.")]
        [RegExp(@"^(\w{2,30})$", "Product Name should contain only 2 to 30 characters.")]
        public string ProductName { get; set; }

        [Required("Product Code can't be blank.")]
        [RegExp(@"^(\w{2,5})$", "Product Code should contain only 2 to 5 characters.")]
        public string ProductCode { get; set; }

        public double ProductPrice { get; set; }
        public string ProductType { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }

        //Constructor to initialize with default values
        public Product()
        {
            ProductID = default(Guid);
            ProductName = string.Empty;
            ProductCode = string.Empty;
            ProductType = string.Empty;
            ProductPrice = default(double);
            CreationDateTime = default(DateTime);
            LastModifiedDateTime = default(DateTime);
        }
    }
}